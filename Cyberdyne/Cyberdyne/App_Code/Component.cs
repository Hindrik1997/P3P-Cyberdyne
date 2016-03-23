using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Component
/// </summary>
public class Component : RepoObject
{



    public Component(int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        //
        // TODO: Add constructor logic here
        //   
    }

    public override void GetObjectData()
    {

    }

    public override void UpdateData()
    {
        throw new NotImplementedException();
    }
}