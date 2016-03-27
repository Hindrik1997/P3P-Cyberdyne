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
    /// <summary>
    /// Database object voor connecties. Gebruik deze graag als het mogelijk is, zodat het aantal objecten niet mega groot wordt
    /// </summary>
    public Database db;

    public RepoManager()
    {
    }

    public Repository<Robot> robotRepository = null;
    public Repository<RobotMovie> robotMovieRepository = null;
    public Repository<RobotImage> robotImageRepository = null;

    public Repository<Component> componentRepository = null;
    public Repository<File> fileRepository = null;

    public Repository<Software> softwareRepository = null;
    public Repository<Supplier> supplierRepository = null;

    /*
    WAARSCHUWING: Gebruik je een van de GetItem of GetBasicItem methodes, dan worden alle item in de repo ge killed, dus houdt hier rekening mee!
    Dus ga niet domweg vanalles tegelijkertijd gebruiken ofzo, maar stuk voor stuk. Dank u      
        */

    /// <summary>
    /// Called voor elk object in de repo de GetObjectData methode. 
    /// </summary>
    /// <typeparam name="T">Type van het item in de repository, moet een afstamemling van RepoObject zijn</typeparam>
    /// <param name="repoRef">Repository reference</param>
    void FillAllDataInRepo<T>(Repository<T> repoRef) where T : RepoObject
    {
        foreach (T obj in repoRef)
        {
            obj.GetObjectData();
        }
    }

    /// <summary>
    /// De interne methodes voor het laden van de basis eigenschappen van een database object.
    /// </summary>
    #region Protected Basic Methodes
    protected void GetBasicRobotData()
    {
        robotRepository = new Repository<Robot>(this);
        IEnumerable<dynamic> Data = db.Query("SELECT * FROM Robots");

        foreach (var Row in Data)
        {
            robotRepository.Add(new Robot(Row["Name"], Row["Category"], Row["RobotID"], this));
        }
    }
    protected void GetBasicRobotMovieData()
    {
        robotMovieRepository = new Repository<RobotMovie>(this);

        IEnumerable<dynamic> Data = db.Query("SELECT * FROM RobotMovies");

        foreach (var Row in Data)
        {
            robotMovieRepository.Add(new RobotMovie(Row["Titel"], Row["RobotID"], Row["Location"], Row["MovieID"], this));
        }
    }
    protected void GetBasicRobotImageData()
    {
        robotImageRepository = new Repository<RobotImage>(this);
        IEnumerable<dynamic> Data = db.Query("SELECT * FROM RobotImages");

        foreach (var Row in Data)
        {
            robotImageRepository.Add(new RobotImage(Row["Name"], Row["ImgLocation"], Row["RobotID"], Row["ImageID"], this));
        }
    }
    protected void GetBasicComponentData()
    {
        componentRepository = new Repository<Component>(this);
        IEnumerable<dynamic> Data = db.Query("SELECT * FROM Components");

        foreach (var Row in Data)
        {
            componentRepository.Add(new Component(Row["ComponentNumber"], Row["ComponentName"], Row["Price"], Row["ComponentID"], this));
        }
    }
    protected void GetBasicFileData()
    {
        fileRepository = new Repository<File>(this);

        IEnumerable<dynamic> Data = db.Query("SELECT * FROM Files");

        foreach (var Row in Data)
        {
            fileRepository.Add(new File(Row["Name"], Row["Location"], Row["Version"], Row["RobotID"], Row["FileID"], this));
        }
    }
    protected void GetBasicSoftwareData()
    {
        softwareRepository = new Repository<Software>(this);

        IEnumerable<dynamic> Data = db.Query("SELECT * FROM Files");

        foreach (var Row in Data)
        {
            fileRepository.Add(new File(Row["Name"], Row["Location"], Row["Version"], Row["RobotID"], Row["FileID"], this));
        }
    }
    protected void GetBasicSupplierData()
    {
        supplierRepository = new Repository<Supplier>(this);
        IEnumerable<dynamic> Data = db.Query("SELECT * FROM Supplier");

        foreach (var Row in Data)
        {
            supplierRepository.Add(new Supplier(Row["Name"], Row["Address"], Row["SupplierID"], this));
        }
    }
    #endregion

    /// <summary>
    /// Call deze methodes als je een complete lijst met álle data wilt inc. dependent objecten.
    /// Liever niet teveel gebruiken tenzij strict noodzakelijk.
    /// Deze methoden invalideert elk object die hiervoor in de repo zat
    /// </summary>
    #region Publieke Geavanceerde Methodes
    public List<Robot> GetRobots()
    {
        db = Database.Open("Cyberdyne");
        GetBasicRobotData();
        GetBasicRobotImages();
        //Softwares inladen
        GetSoftwares();
        //Componenten inladen
        GetComponents();
        //GetRobotImages, Movies, Files
        GetFiles(); GetRobotImages(); GetRobotMovies();
        FillAllDataInRepo(robotRepository);
        db.Close();
        return robotRepository.GetList();
    }
    public List<Component> GetComponents()
    {
        db = Database.Open("Cyberdyne");
        GetBasicComponentData();
        GetSuppliers();
        FillAllDataInRepo(supplierRepository);
        FillAllDataInRepo(componentRepository);
        db.Close();
        return componentRepository.GetList();
    }
    public List<File> GetFiles()
    {
        db = Database.Open("Cyberdyne");
        GetBasicFileData();
        try
        {
            if (robotRepository != null)
                FillAllDataInRepo(fileRepository);
            else
                throw new NullReferenceException("robot repo is null!");
        }
        finally
        {
            db.Close();
        }
        return fileRepository.GetList();
    }
    public List<RobotMovie> GetRobotMovies()
    {
        db = Database.Open("Cyberdyne");
        GetBasicRobotMovieData();
        try
        {
            if (robotRepository != null)
                FillAllDataInRepo(robotMovieRepository);
            else
                throw new NullReferenceException("robot repo is either null!");
        }
        finally
        {
            db.Close();
        }
        db.Close();
        return robotMovieRepository.GetList();
    }
    public List<RobotImage> GetRobotImages()
    {
        db = Database.Open("Cyberdyne");
        GetBasicRobotImageData();
        try
        {
            if (robotRepository != null)
                FillAllDataInRepo(robotImageRepository);
            else
                throw new NullReferenceException("robot repo is null!");
        }
        finally
        {
            db.Close();
        }
        return robotImageRepository.GetList();
    }
    public List<Software> GetSoftwares()
    {
        db = Database.Open("Cyberdyne");
        GetBasicSoftwareData();
        try
        {
            if (robotRepository != null)
                FillAllDataInRepo(softwareRepository);
            else
                throw new NullReferenceException("robot repo is null!");
        }
        finally
        {
            db.Close();
        }
        return softwareRepository.GetList();
    }
    public List<Supplier> GetSuppliers()
    {
        db = Database.Open("Cyberdyne");
        GetBasicSupplierData();
        FillAllDataInRepo(supplierRepository); //Type wordt wel in runtime geresolved
        db.Close();
        return supplierRepository.GetList();
    }
    #endregion


    /// <summary>
    /// Call deze methods als je simpele data wilt, voor displayen etc.
    ///Deze methods halen enkel de basis data op voor een object. 
    ///Call GetObjectData() op een object voor meer data
    /// </summary>
    #region Publieke Basic Methodes
    public List<Robot> GetBasicRobots()
    {
        db = Database.Open("Cyberdyne");
        GetBasicRobotData();
        GetBasicRobotImages();
        db.Close();
        return robotRepository.GetList();
    }
    public List<Component> GetBasicComponentDatas()
    {
        db = Database.Open("Cyberdyne");
        GetBasicComponentData();
        db.Close();
        return componentRepository.GetList();
    }
    public List<File> GetBasicFiles()
    {
        db = Database.Open("Cyberdyne");
        GetBasicFileData();
        db.Close();
        return fileRepository.GetList();
    }
    public List<RobotMovie> GetRobotBasicMovies()
    {
        db = Database.Open("Cyberdyne");
        GetBasicRobotMovieData();
        db.Close();
        return robotMovieRepository.GetList();
    }
    public List<RobotImage> GetBasicRobotImages()
    {
        db = Database.Open("Cyberdyne");
        GetBasicRobotImageData();
        db.Close();
        return robotImageRepository.GetList();
    }
    public List<Software> GetBasicSoftwares()
    {
        db = Database.Open("Cyberdyne");
        GetBasicSoftwareData();
        db.Close();
        return softwareRepository.GetList();
    }
    public List<Supplier> GetBasicSuppliers()
    {
        db = Database.Open("Cyberdyne");
        GetBasicSupplierData();
        db.Close();
        return supplierRepository.GetList();
    }
    #endregion

    //SEARCHEN ENZO MOET ER NOG IN!
    #region Publieke Zoek Methodes Robots
    public List<Robot> GetRobotsByName(string Search)
    {
        db = Database.Open("Cyberdyne");
        GetBasicRobotDataByName(Search);
        GetBasicRobotImages();
        //Softwares inladen
        GetSoftwares();
        //Componenten inladen
        GetComponents();
        //GetRobotImages, Movies, Files
        GetFiles(); GetRobotImages(); GetRobotMovies();
        FillAllDataInRepo(robotRepository);
        db.Close();
        return robotRepository.GetList();
    }

    protected void GetBasicRobotDataByName(string Search)
    {
        robotRepository = new Repository<Robot>(this);
        string sql = @"
        SELECT Robots.Name, Robots.Category, Robots.RobotID 
            FROM Robots 
            Where Robots.Name LIKE @0 
        UNION SELECT Robots.Name, Robots.Category, Robots.RobotID 
            FROM Robots, ComponentList, Components 
            Where Components.ComponentName LIKE @0 AND Robots.RobotID = ComponentList.RobotID AND Components.ComponentID = ComponentList.ComponentID";
        IEnumerable<dynamic> Data = db.Query(sql, Search);
        foreach (var Row in Data)
        {
            robotRepository.Add(new Robot(Row["Name"], Row["Category"], Row["RobotID"], this));
        }
    }
    #endregion

    #region Publieke Zoek Methodes Parts
    public List<Component> GetPartsByName(string Search)
    {
        db = Database.Open("Cyberdyne");
        GetBasicPartsDataByNameOrRobot(Search);
        FillAllDataInRepo(componentRepository);
        db.Close();
        return componentRepository.GetList();
    }

    protected void GetBasicPartsDataByNameOrRobot(string Search)
    {
        componentRepository = new Repository<Component>(this);
        string sql = @"
        SELECT Components.ComponentID, Components.ComponentNumber, Components.SupplierID, Components.Price, Components.ComponentName, ComponentList.Quantity, ComponentList.RobotID, Robots.Name  
            FROM Components
        LEFT JOIN ComponentList
            ON Components.ComponentID=ComponentList.ComponentID 
        LEFT JOIN Robots
            ON ComponentList.RobotID=Robots.RobotID
        WHERE Components.ComponentName LIKE @0 OR Components.ComponentNumber LIKE @0 OR Robots.Name LIKE @0";
        IEnumerable<dynamic> Data = db.Query(sql, Search);
        foreach (var Row in Data)
        {
            componentRepository.Add(new Component(Row["ComponentNumber"], Row["ComponentName"], Row["Price"], Row["ComponentID"], this, Row["RobotID"], Row["Name"], Row["Quantity"], Row["SupplierID"]));
        }
    }
    #endregion
}