using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for Robot
/// </summary>
public class Robot : RepoObject
{
    public string name { get; set; }

    public string category { get; set; }

    public Software software { get; set; }

    public List<ComponentData> components { get; set; }

    public List<File> files { get; set; }

    public List<RobotImage> images { get; set; }

    public List<RobotMovie> movies { get; set; }

    public string descriptionDutch { get; set; }

    public string descriptionEnglish { get; set; }

    public Robot(string _Naam, string _Category, int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        category = _Category;
        name = _Naam;
    }

    public override void GetObjectData()
    {
        foreach (Software Sw in repoRef.softwareRepository)
        {
            if (Sw.robotID == ID)
            {
                software = Sw;
                break;
            }
        }
        Database Db = Database.Open("Cyberdyne");
        //Fetch text
        dynamic TextNL = Db.QueryValue("SELECT DescriptionNL FROM Robots WHERE RobotID = @0", ID);
        dynamic TextENG = Db.QueryValue("SELECT DescriptionENG FROM Robots WHERE RobotID = @0", ID);
        descriptionDutch = Convert.ToString(TextNL);
        descriptionEnglish = Convert.ToString(TextENG);

        IEnumerable<dynamic> result = Db.Query("SELECT * FROM ComponentList WHERE RobotID = @0", ID);
        components = new List<ComponentData>();

        foreach (var Item in result)
        {
            //ComponentID ophalen en zoeken naar bijhorende component en deze aan de componentlijst toevoegen
            foreach (Component P in repoRef.componentRepository)
            {
                if (P.ID == (int)Item["ComponentID"])
                {
                    components.Add(new ComponentData(P, (int)Item["Quantity"]));
                    break;
                }
            }
        }
        Db.Close();
        images = new List<RobotImage>();
        foreach (RobotImage RI in repoRef.robotImageRepository)
        {
            if (RI.robotID == ID)
            {
                images.Add(RI);
            }
        }
        movies = new List<RobotMovie>();
        foreach (RobotMovie RM in repoRef.robotMovieRepository)
        {
            if (RM.robotID == ID)
            {
                movies.Add(RM);
            }
        }

        files = new List<File>();
        foreach (File F in repoRef.fileRepository)
        {
            if (F.RobotID == ID)
            {
                files.Add(F);
            }
        }
    }
    public override void UpdateData()
    {
        Database db = Database.Open("Cyberdyne");
        if (Exist())
            db.Execute("UPDATE Robots SET Name=@0, Category=@1, DescriptionNL=@2, DescriptionENG=@3 WHERE RobotID =@4", name, category, descriptionDutch, descriptionEnglish, ID);
        else
        {
            db.Execute("INSERT INTO Robots (Name, Category, DescriptionNL, DescriptionENG) VALUES (@0, @1, @2, @3)", name, category, descriptionDutch, descriptionEnglish);
            ID = db.QueryValue("SELECT RobotID FROM Robots WHERE RobotID = @@IDENTITY");
        }
        db.Close();
    }

    public bool Exist()
    {
        Database db = Database.Open("Cyberdyne");
        var commandText = @"SELECT COUNT(*) FROM Robots WHERE RobotID = @0";
        return (int)db.QueryValue(commandText, ID) > 0;
    }
}