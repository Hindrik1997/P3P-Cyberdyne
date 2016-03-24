using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RobotMovies
/// </summary>
public class RobotMovie : RepoObject
{
    public string Name { get; set; }
    public string Location { get; set; }
    public int RobotID {get; set;}

    public Robot ReferencedRobot { get; private set; }

    public RobotMovie(string _Name, int _RobotID, string _Location, int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        Name = _Name;
        RobotID = _RobotID;
    }

    public override void GetObjectData()
    {
        throw new NotNecessaryException();//Needs it later on tough
    }

    public override void UpdateData()
    {
        throw new NotImplementedException();
    }
}