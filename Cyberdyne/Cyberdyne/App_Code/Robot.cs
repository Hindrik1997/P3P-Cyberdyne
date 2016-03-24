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
    public string Naam { get; set; }

    public string Category { get; set; }

    public Software Software { get; set; }

    public List<ComponentData> Components { get; set; }

    public List<File> Files { get; set; }

    public List<RobotImage> Images { get; set; }

    public List<RobotMovie> Movies { get; set; }

    public string DescriptionDutch { get; set; }

    public string DescriptionEnglish { get; set; }

    public Robot(string _Naam, string _Category, int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        Category = _Category;
        Naam = _Naam;
    }

    public override void GetObjectData()
    {
        //Zoeken naar referenties
        foreach (Software Sw in RepoRef.SoftwareRepository)
        {
            if (Sw.RobotID == ID)
            {
                Software = Sw;
                break;
            }
        }
        Database Db = Database.Open("Cyberdyne");
        //Fetch text
        dynamic TextNL = Db.QueryValue("SELECT DescriptionNL FROM Robots WHERE RobotID = @0", ID);
        dynamic TextENG = Db.QueryValue("SELECT DescriptionENG FROM Robots WHERE RobotID = @0", ID);
        DescriptionDutch = Convert.ToString(TextNL);
        DescriptionEnglish = Convert.ToString(TextENG);

        IEnumerable<dynamic> result = Db.Query("SELECT * FROM ComponentList WHERE RobotID = @0", ID);
        Components = new List<ComponentData>();
        foreach (var Item in result)
        {
            //ComponentID ophalen en zoeken naar bijhorende component en deze aan de componentlijst toevoegen
            foreach (Component P in RepoRef.ComponentRepository)
            {
                if (P.ID == (int)Item["ComponentID"])
                {
                    Components.Add(new ComponentData(P, (int)Item["Quantity"]));
                    break;
                }
            }
        }
        Db.Close();
        Images = new List<RobotImage>();
        foreach (RobotImage RI in RepoRef.RobotImageRepository)
        {
            if (RI.RobotID == ID)
            {
                Images.Add(RI);
            }
        }
        Movies = new List<RobotMovie>();
        foreach (RobotMovie RM in RepoRef.RobotMovieRepository)
        {
            if (RM.RobotID == ID)
            {
                Movies.Add(RM);
            }
        }

        Files = new List<File>();
        foreach (File F in RepoRef.FileRepository)
        {
            if (F.RobotID == ID)
            {
                Files.Add(F);
            }
        }
    }
    public override void UpdateData()
    {
        throw new NotImplementedException();
    }
}