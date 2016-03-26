using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

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
        Database db = Database.Open("Cyberdyne");
        bool exist = Exist();

        if (exist)
            db.Execute("UPDATE Software SET Name=@0, Location=@1, Version=@2, RobotID=@3 WHERE SoftwareID =@4", name, location, version, robotID, ID);
        else
        {
            db.Execute("INSERT INTO Software (Name, Location, Version, RobotID) VALUES @0, @1, @2, @3", name, location, version, robotID);
            ID = db.QueryValue("SELECT SoftwareID FROM Software WHERE SoftwareID = @@IDENTITY");
        }
        db.Close();
    }
    public bool Exist()
    {
        Database db = Database.Open("Cyberdyne");
        var commandText = @"SELECT COUNT(*) FROM Software WHERE SoftwareID = @0";
        return (int)db.QueryValue(commandText, ID) > 0;
    }
}