using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

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
        Database db = Database.Open("Cyberdyne");
        bool exist = Exist();

        if (exist)
            db.Execute("UPDATE RobotImages SET Name=@0, ImgLocation=@1, RobotID=@2 WHERE ImageID =@3", name, imageLocation, robotID, ID);
        else
        {
            db.Execute("INSERT INTO RobotImages (Name, ImgLocation, RobotID) VALUES @0, @1, @2", name, imageLocation, robotID);
            ID = db.QueryValue("SELECT ImageID FROM RobotImages WHERE ImageID = @@IDENTITY");
        }
        db.Close();
    }
    public bool Exist()
    {
        Database db = Database.Open("Cyberdyne");
        var commandText = @"SELECT COUNT(*) FROM RobotImages WHERE ImageID = @0";
        return (int)db.QueryValue(commandText, ID) > 0;
    }
}