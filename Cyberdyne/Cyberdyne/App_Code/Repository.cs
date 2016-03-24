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

    private List<T> repoContents = new List<T>();

    public List<T> GetList()
    {
        return repoContents;
    }

    public void Add(T Item)
    {
        repoContents.Add(Item);
    }

    public void Remove(T Item)
    {
        repoContents.Remove(Item);
    }

    public T this[int index]
    {
        get { if (index < 0 || index > repoContents.Count)
                throw new IndexOutOfRangeException();
            return repoContents[index];
        }
        set {
            if (index < 0 || index > repoContents.Count)
                throw new IndexOutOfRangeException();
            repoContents[index] = value;
        }
    }

    public int Count()
    {
        return repoContents.Count();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return repoContents.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return repoContents.GetEnumerator();
    }
}