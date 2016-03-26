using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for RepoObject
/// </summary>
public abstract class RepoObject
{
    public int ID { get;  set; }
    protected RepoManager repoRef;


    public RepoObject(int _ID, RepoManager _RepoRef)
    {
        ID = _ID;
        repoRef = _RepoRef;
    }

    public abstract void GetObjectData();
    public abstract void UpdateData();
}