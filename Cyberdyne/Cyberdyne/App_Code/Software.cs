using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Software
/// </summary>
public class Software : RepoObject
{
    public Software(int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
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