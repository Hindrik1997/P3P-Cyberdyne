using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Software
/// </summary>
public class Software : RepoObject
{
    public string name { get; set; }
    public string location { get; set; }
    public string version { get; set; }

    public int robotID { get; set; }
       
    public Robot ReferencedRobot { get; private set; }

    public Software(string name, string location, string version, int robotID, int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        this.name = name;
        this.location = location;
        this.version = version;
        this.robotID = robotID;
    }

    public override void GetObjectData()
    {
        throw new NotImplementedException();
    }

    public override void UpdateData()
    {
        throw new NotImplementedException();
    }
}