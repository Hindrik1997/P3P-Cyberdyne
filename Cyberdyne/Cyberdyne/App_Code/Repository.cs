using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Repository class
/// </summary>
public class Repository<T> : IEnumerable<T> where  T : RepoObject
{
    RepoManager m_ParentRepo = null;
    public Repository(RepoManager _Manager)
    {
        m_ParentRepo = _Manager;
    }

    private List<T> RepoContents = new List<T>();

    public void Add(T Item)
    {
        RepoContents.Add(Item);
    }

    public void Remove(T Item)
    {
        RepoContents.Remove(Item);
    }

    public T this[int index]
    {
        get { if (index < 0 || index > RepoContents.Count)
                throw new IndexOutOfRangeException();
            return RepoContents[index];
        }
        set {
            if (index < 0 || index > RepoContents.Count)
                throw new IndexOutOfRangeException();
            RepoContents[index] = value;
        }
    }

    public int Count()
    {
        return RepoContents.Count();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return RepoContents.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return RepoContents.GetEnumerator();
    }
}