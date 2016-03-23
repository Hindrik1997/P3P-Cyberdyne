using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for RepoManager
/// </summary>
public class RepoManager
{
    public Database db;

    public RepoManager()
    {
        RobotRepository = new Repository<Robot>(this);
        RobotMovieRepository = new Repository<RobotMovie>(this);
        RobotImageRepository = new Repository<RobotImage>(this);
        ComponentRepository = new Repository<Component>(this);
        FileRepository = new Repository<File>(this);
        SoftwareRepository = new Repository<Software>(this);
        SupplierRepository = new Repository<Supplier>(this);
    }

    private Repository<Robot> RobotRepository = null;
    private Repository<RobotMovie> RobotMovieRepository = null;
    private Repository<RobotImage> RobotImageRepository = null;

    private Repository<Component> ComponentRepository = null;
    private Repository<File> FileRepository = null;

    private Repository<Software> SoftwareRepository = null;
    private Repository<Supplier> SupplierRepository = null;

    protected void GetBasicRobotData()
    {
        if (RobotRepository == null)
            throw new NullReferenceException("Jo, de roborepo is null!");
        db = Database.Open("Cyberdyne");

        IEnumerable<dynamic> Data = db.Query("SELECT * FROM Robots");

        foreach (var Row in Data)
        {
            RobotRepository.Add(new Robot(Row["Name"], Row["Category"], Row["RobotID"],this));
        }
    }
    protected void GetBasicRobotMovieData()
    {
        if (RobotMovieRepository == null)
            throw new NullReferenceException("Jo, de robomovierepo is null!");
        db = Database.Open("Cyberdyne");

        IEnumerable<dynamic> Data = db.Query("SELECT * FROM RobotMovies");

        foreach (var Row in Data)
        {
            RobotMovieRepository.Add(new RobotMovie(Row["Titel"],Row["RobotID"], Row["Location"],Row["MovieID"], this));
        }
    }
    protected void GetBasicRobotImageData()
    {
        if (RobotImageRepository == null)
            throw new NullReferenceException("Jo, de roboimagerepo is null!");
        db = Database.Open("Cyberdyne");

        IEnumerable<dynamic> Data = db.Query("SELECT * FROM RobotImages");

        foreach (var Row in Data)
        {
            RobotImageRepository.Add(new RobotImage(Row["Name"], Row["ImgLocation"], Row["RobotID"], Row["ImageID"], this));
        }
    }
    
    //REFERENCES MOETEN NOG! ZIE ROBOT CLASS

    //Michael, implementeer de volgende methods zoals de methods hierboven, de rest doen we morgen wel
    #region MichaelCode
    protected void GetBasicComponentData()
    {
        
    }

    protected void GetBasicFileData()
    {
       
    }

    protected void GetBasicSoftwareData()
    {
       
    }

    protected void GetBasicSupplierData()
    {
        
    }
    #endregion


}