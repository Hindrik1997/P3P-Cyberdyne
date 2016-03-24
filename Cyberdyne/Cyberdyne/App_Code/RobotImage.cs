using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RobotImage
/// </summary>
public class RobotImage : RepoObject
{
    public string name { get; set; }
    public string imageLocation { get; set; }
    public int robotID { get; set; }
    public Robot referencedRobot { get; private set; }

    public RobotImage(string _Name,string _ImageLocation, int _RobotID,int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        name = _Name;
        imageLocation = _ImageLocation;
        robotID = _RobotID;
        referencedRobot = null;
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