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

    public Software(string _Name, string _Location, string _Version, int _RobotID, int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        name = _Name;
        location = _Location;
        version = _Version;
        robotID = _RobotID;
    }

    public override void GetObjectData()
    {
        foreach (Robot RB in repoRef.robotRepository)
        {
            if (RB.ID == robotID)
            {
                ReferencedRobot = RB;
                break;
            }
        }
    }

    public override void UpdateData()
    {
        throw new NotImplementedException();
    }
}