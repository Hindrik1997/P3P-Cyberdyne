using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RobotImage
/// </summary>
public class RobotImage : RepoObject
{
    public string Name { get; set; }
    public string ImageLocation { get; set; }
    public int RobotID { get; set; }
    public Robot ReferencedRobot { get; private set; }

    public RobotImage(string _Name,string _ImageLocation, int _RobotID,int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        Name = _Name;
        ImageLocation = _ImageLocation;
        RobotID = _RobotID;
        ReferencedRobot = null;
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