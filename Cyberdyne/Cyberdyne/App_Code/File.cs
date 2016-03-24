using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for File
/// </summary>
public class File : RepoObject
{
    public string name { get; set; }
    public string location { get; set; }
    public string version { get; set; }

    public int RobotID { get; set; }

    public Robot ReferencedRobot { get; private set; }

    public File(string name, string location, string version, int robotID, int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        this.name = name;
        this.location = location;
        this.version = version;
        this.RobotID = robotID;
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