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

    public Repository<Robot> RobotRepository = null;
    public Repository<RobotMovie> RobotMovieRepository = null;
    public Repository<RobotImage> RobotImageRepository = null;

    public Repository<Component> ComponentRepository = null;
    public Repository<File> FileRepository = null;

    public Repository<Software> SoftwareRepository = null;
    public Repository<Supplier> SupplierRepository = null;

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

    //IS GOED DOEN WE MORGEN! *Donderdag

    //Michael, implementeer de volgende methods zoals de methods hierboven, de rest doen we morgen wel
    #region MichaelCode
    protected void GetBasicComponentData()
    {
        if (ComponentRepository == null)
            throw new NullReferenceException("null gedoe");

        db = Database.Open("Cyberdyne");

        IEnumerable<dynamic> Data = db.Query("SELECT * FROM Components");

        foreach (var Row in Data)
        {
            ComponentRepository.Add(new Component(Row["ComponentNumber"], Row["Price"], Row["DescriptionNL"], Row["DescriptionENG"], Row["ComponentID"], this));
        }

    }

    protected void GetBasicFileData()
    {
        if (FileRepository == null)
            throw new NullReferenceException("null gedoe");
        db = Database.Open("Cyberdyne");

        IEnumerable<dynamic> Data = db.Query("SELECT * FROM Files");

        foreach (var Row in Data)
        {
            FileRepository.Add(new File(Row["Name"], Row["Location"], Row["Version"], Row["RobotID"], Row["FileID"], this));
        }

    }

    protected void GetBasicSoftwareData()
    {
        if (FileRepository == null)
            throw new NullReferenceException("null gedoe");
        db = Database.Open("Cyberdyne");

        IEnumerable<dynamic> Data = db.Query("SELECT * FROM Files");

        foreach (var Row in Data)
        {
            FileRepository.Add(new File(Row["Name"], Row["Location"], Row["Version"], Row["RobotID"], Row["FileID"], this));
        }
    }

    protected void GetBasicSupplierData()
    {
        if (SupplierRepository == null)
            throw new NullReferenceException("null gedoe");
        db = Database.Open("Cyberdyne");

        IEnumerable<dynamic> Data = db.Query("SELECT * FROM Supplier");

        foreach (var Row in Data)
        {
            SupplierRepository.Add(new Supplier(Row["Name"], Row["Address"], Row["SupplierID"], this));
        }
    }

    public Robot ItemExist<T> (int _ID) where T : Robot
    {
        foreach (var Robot in RobotRepository)
        {
            if (Robot.ID == _ID)
                return Robot;
        }
        return null;
    }
    
    #endregion


}