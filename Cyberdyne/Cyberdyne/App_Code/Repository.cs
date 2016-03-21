using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Repository class
/// </summary>
public class Repository<T> where  T : RepoObject
{
    RepoManager m_ParentRepo = null;
    public Repository(RepoManager _Manager)
    {
        m_ParentRepo = _Manager;
    }

    private  List<T> RepoContents;
    


}