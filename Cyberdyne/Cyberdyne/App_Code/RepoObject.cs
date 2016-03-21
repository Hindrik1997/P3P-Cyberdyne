using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RepoObject
/// </summary>
public abstract class RepoObject
{
    public readonly int ID;

    public RepoObject(int _ID)
    {
        ID = _ID;
    }

    public abstract void GetObjectData();
}