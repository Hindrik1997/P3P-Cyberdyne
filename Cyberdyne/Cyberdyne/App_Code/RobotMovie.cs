using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

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
        location = _Location;
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
        Database db = Database.Open("Cyberdyne");
        if (Exist())
            db.Execute("UPDATE RobotMovies SET Titel=@0, Location=@1, RobotID=@2 WHERE MovieID =@3", name, location, robotID, ID);
        else
        {
            db.Execute("INSERT INTO RobotMovies (Titel, Location, RobotID) VALUES (@0, @1, @2)", name, location, robotID);
            ID = db.QueryValue("SELECT MovieID FROM RobotMovies WHERE MovieID = @@IDENTITY");
        }
        db.Close();
    }
    public bool Exist()
    {
        Database db = Database.Open("Cyberdyne");
        var commandText = @"SELECT COUNT(*) FROM RobotMovies WHERE MovieID = @0";
        return (int)db.QueryValue(commandText, ID) > 0;
    }
}