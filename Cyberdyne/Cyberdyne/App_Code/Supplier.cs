using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Supplier
/// </summary>
public class Supplier : RepoObject
{
    public Supplier(int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public override void GetObjectData()
    {
        throw new NotImplementedException();
    }
}