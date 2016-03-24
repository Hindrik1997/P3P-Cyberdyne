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

    public int RobotID { get; set; }
       
    public Robot ReferencedRobot { get; private set; }

    public Software(string _Name, string _Location, string _Version, int _RobotID, int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        this.name = _Name;
        this.location = _Location;
        this.version = _Version;
        RobotID = _RobotID;
    }

    public override void GetObjectData()
    {
        foreach (Robot RB in RepoRef.RobotRepository)
        {
            if (RB.ID == RobotID)
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