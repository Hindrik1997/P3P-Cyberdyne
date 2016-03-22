using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Robot
/// </summary>
public class Robot : RepoObject
{
    public string Naam { get; set; }



    public Robot(int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        
    }

    public override void GetObjectData()
    {
        
    }
}