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
    public readonly int ID;
    protected RepoManager RepoRef;


    public RepoObject(int _ID, RepoManager _RepoRef)
    {
        ID = _ID;
        RepoRef = _RepoRef;
    }

    public abstract void GetObjectData();
    public abstract void UpdateData();
}