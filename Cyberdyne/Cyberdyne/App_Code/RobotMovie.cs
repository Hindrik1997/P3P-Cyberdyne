using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RobotMovies
/// </summary>
public class RobotMovie : RepoObject
{
    public string name { get; set; }
    public string location { get; set; }
    public int robotID {get; set;}

    public Robot referencedRobot { get; private set; }

    public RobotMovie(string _Name, int _RobotID, string _Location, int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        name = _Name;
        robotID = _RobotID;
    }

    public override void GetObjectData()
    {
        foreach (Robot RB in repoRef.robotRepository)
        {
            if (RB.ID == robotID)
            {
                referencedRobot = RB;
                break;
            }
        }
    }

    public override void UpdateData()
    {
        throw new NotImplementedException();
    }
}