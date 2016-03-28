using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for File
/// </summary>
public class RobotFile : RepoObject
{
    public string name { get; set; }
    public string location { get; set; }
    public string version { get; set; }

    public int RobotID { get; set; }

    public Robot ReferencedRobot { get; private set; }

    public RobotFile(string name, string location, string version, int robotID, int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        this.name = name;
        this.location = location;
        this.version = version;
        this.RobotID = robotID;
    }

    public override void GetObjectData()
    {
        foreach (Robot RB in repoRef.robotRepository)
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
        Database db = Database.Open("Cyberdyne");
        if (Exist())
            db.Execute("UPDATE Files SET Name=@0, Location=@1, Version=@2, RobotID=@3 WHERE FileID =@4", name, location, version, RobotID, ID);
        else
        {
            db.Execute("INSERT INTO Files (Name, Location, Version, RobotID) VALUES (@0, @1, @2, @3)", name, location, version, RobotID);
            ID = db.QueryValue("SELECT FileID FROM Files WHERE FileID = @@IDENTITY");
        }
        db.Close();
    }
    public bool Exist()
    {
        Database db = Database.Open("Cyberdyne");
        var commandText = @"SELECT COUNT(*) FROM Files WHERE FileID = @0";
        return (int)db.QueryValue(commandText, ID) > 0;
    }
}