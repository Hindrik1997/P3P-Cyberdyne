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
        robotRepository = new Repository<Robot>(this);
        robotMovieRepository = new Repository<RobotMovie>(this);
        robotImageRepository = new Repository<RobotImage>(this);
        componentRepository = new Repository<Component>(this);
        fileRepository = new Repository<File>(this);
        softwareRepository = new Repository<Software>(this);
        supplierRepository = new Repository<Supplier>(this);
    }

    public Repository<Robot> robotRepository = null;
    public Repository<RobotMovie> robotMovieRepository = null;
    public Repository<RobotImage> robotImageRepository = null;

    public Repository<Component> componentRepository = null;
    public Repository<File> fileRepository = null;

    public Repository<Software> softwareRepository = null;
    public Repository<Supplier> supplierRepository = null;

    protected void GetBasicRobotData()
    {
        if (robotRepository == null)
            throw new NullReferenceException("Jo, de roborepo is null!");
        db = Database.Open("Cyberdyne");

        IEnumerable<dynamic> Data = db.Query("SELECT * FROM Robots");

        foreach (var Row in Data)
        {
            robotRepository.Add(new Robot(Row["Name"], Row["Category"], Row["RobotID"],this));
        }
        db.Close();
    }
    protected void GetBasicRobotMovieData()
    {
        if (robotMovieRepository == null)
            throw new NullReferenceException("Jo, de robomovierepo is null!");
        db = Database.Open("Cyberdyne");

        IEnumerable<dynamic> Data = db.Query("SELECT * FROM RobotMovies");

        foreach (var Row in Data)
        {
            robotMovieRepository.Add(new RobotMovie(Row["Titel"],Row["RobotID"], Row["Location"],Row["MovieID"], this));
        }
        db.Close();
    }
    protected void GetBasicRobotImageData()
    {
        if (robotImageRepository == null)
            throw new NullReferenceException("Jo, de roboimagerepo is null!");
        db = Database.Open("Cyberdyne");

        IEnumerable<dynamic> Data = db.Query("SELECT * FROM RobotImages");

        foreach (var Row in Data)
        {
            robotImageRepository.Add(new RobotImage(Row["Name"], Row["ImgLocation"], Row["RobotID"], Row["ImageID"], this));
        }
        db.Close();
    }
    
    //REFERENCES MOETEN NOG! ZIE ROBOT CLASS  

    //IS GOED DOEN WE MORGEN! *Donderdag

    //Michael, implementeer de volgende methods zoals de methods hierboven, de rest doen we morgen wel
    #region MichaelCode
    protected void GetBasicComponentData()
    {
        if (componentRepository == null)
            throw new NullReferenceException("null gedoe");

        db = Database.Open("Cyberdyne");

        IEnumerable<dynamic> Data = db.Query("SELECT * FROM Components");

        foreach (var Row in Data)
        {
            componentRepository.Add(new Component(Row["ComponentNumber"], Row["Price"], Row["ComponentID"], this));
        }
        db.Close();
    }

    protected void GetBasicFileData()
    {
        if (fileRepository == null)
            throw new NullReferenceException("null gedoe");
        db = Database.Open("Cyberdyne");

        IEnumerable<dynamic> Data = db.Query("SELECT * FROM Files");

        foreach (var Row in Data)
        {
            fileRepository.Add(new File(Row["Name"], Row["Location"], Row["Version"], Row["RobotID"], Row["FileID"], this));
        }
        db.Close();
    }

    protected void GetBasicSoftwareData()
    {
        if (fileRepository == null)
            throw new NullReferenceException("null gedoe");
        db = Database.Open("Cyberdyne");

        IEnumerable<dynamic> Data = db.Query("SELECT * FROM Files");

        foreach (var Row in Data)
        {
            fileRepository.Add(new File(Row["Name"], Row["Location"], Row["Version"], Row["RobotID"], Row["FileID"], this));
        }
        db.Close();
    }

    protected void GetBasicSupplierData()
    {
        if (supplierRepository == null)
            throw new NullReferenceException("null gedoe");
        db = Database.Open("Cyberdyne");

        IEnumerable<dynamic> Data = db.Query("SELECT * FROM Supplier");

        foreach (var Row in Data)
        {
            supplierRepository.Add(new Supplier(Row["Name"], Row["Address"], Row["SupplierID"], this));
        }
        db.Close();
    }
    #endregion


}