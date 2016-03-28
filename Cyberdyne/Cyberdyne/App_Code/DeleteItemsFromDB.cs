using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;


/// <summary>
/// Summary description for DeleteItemsFromDB
/// </summary>
public class DeleteItemsFromDB
{
    /// <summary>
    /// Database object voor connecties. Gebruik deze graag als het mogelijk is, zodat het aantal objecten niet mega groot wordt
    /// </summary>
    public Database db;



    public DeleteItemsFromDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    #region Delete Component
    public bool ComponentExist(int ComponentID)
    {
        Database db = Database.Open("Cyberdyne");
        var commandText = @"SELECT COUNT(*) FROM Components WHERE ComponentID = @0";
        return (int)db.QueryValue(commandText, ComponentID) > 0;
      
    }

    public bool DeleteComponentFromDB(int ComponentID)
    {
        if (ComponentExist(ComponentID))
        {
            Database db = Database.Open("Cyberdyne");
            int numRowsEffected = db.Execute("DELETE FROM ComponentList WHERE ComponentID = @0",
                ComponentID);

            int numRowsEffected2 = db.Execute("DELETE FROM Components WHERE ComponentID = @0",
                ComponentID);
            db.Close();
            return numRowsEffected > 0 && numRowsEffected2 == 1;
        }
        else
            return false;
        
    }

    public bool DeleteComponentFromRobot(int ComponentID, int RobotID)
    {
        Database db = Database.Open("Cyberdyne");
        int numRowsEffected = db.Execute("DELETE FROM ComponentList WHERE ComponentID = @0 AND RobotID = @1",
            ComponentID, RobotID);
        db.Close();
        return numRowsEffected == 1;
    }
    #endregion

    #region Delete File
    public bool FileExist(int ID)
    {
        Database db = Database.Open("Cyberdyne");
        var commandText = @"SELECT COUNT(*) FROM Files WHERE FileID = @0";
        return (int)db.QueryValue(commandText, ID) > 0;
    }

    public bool RobotFilesExist(int ID)
    {
        Database db = Database.Open("Cyberdyne");
        var commandText = @"SELECT COUNT(*) FROM Files WHERE RobotID = @0";
        return (int)db.QueryValue(commandText, ID) > 0;
    }

    public bool DeleteFilesFromDB(int FileID = -1, int RobotID = -1)
    {
        Database db = Database.Open("Cyberdyne");
        if (RobotID == -1 && FileExist(FileID))
        {

            int numRowsEffected = db.Execute("DELETE FROM Files WHERE FileID = @0",
            FileID);
            db.Close();
            return numRowsEffected == 1;
        }
        if (RobotID > 0 && RobotFilesExist(RobotID))
        {
            int numRowsEffected = db.Execute("DELETE FROM Files WHERE RobotID = @0",
            FileID);
            db.Close();
            return numRowsEffected > 0;
        }
        return false;
    }
    #endregion
    #region Delete Image
    public bool ImageExist(int ID)
    {
        Database db = Database.Open("Cyberdyne");
        var commandText = @"SELECT COUNT(*) FROM RobotImages WHERE ImageID = @0";
        return (int)db.QueryValue(commandText, ID) > 0;
    }

    public bool RobotImagesExist(int RobotID)
    {
        Database db = Database.Open("Cyberdyne");
        var commandText = @"SELECT COUNT(*) FROM RobotImages WHERE RobotID = @0";
        return (int)db.QueryValue(commandText, RobotID) > 0;
    }

    public bool DeleteImageFromDB(int ImageID = -1, int RobotID = -1)
    {
        Database db = Database.Open("Cyberdyne");
        if (RobotID == -1 && ImageExist(ImageID))
        {
          int numRowsEffected = db.Execute("DELETE FROM RobotImages WHERE ImageID = @0",
          ImageID);
          db.Close();
          return numRowsEffected == 1;
        }
        if(RobotID > 0 && RobotImagesExist(RobotID))
        {
          int numRowsEffected = db.Execute("DELETE FROM RobotImages WHERE RobotID = @0",
            RobotID);
          db.Close();
          return numRowsEffected > 0;
        }
        return false;
    }
    #endregion

    #region Delete Movie
    public bool MovieExist(int ID)
    {
        Database db = Database.Open("Cyberdyne");
        var commandText = @"SELECT COUNT(*) FROM RobotMovies WHERE MovieID = @0";
        return (int)db.QueryValue(commandText, ID) > 0;
    }

    public bool RobotMovieExist(int RobotID)
    {
        Database db = Database.Open("Cyberdyne");
        var commandText = @"SELECT COUNT(*) FROM RobotMovies WHERE RobotID = @0";
        return (int)db.QueryValue(commandText, RobotID) > 0;
    }

    public bool DeleteMovieFromDB(int MovieID = -1, int RobotID = -1)
    {
        Database db = Database.Open("Cyberdyne");
        if (RobotID == -1 && MovieExist(MovieID))
        {
            int numRowsEffected = db.Execute("DELETE FROM RobotMovies WHERE MovieID = @0",
                MovieID);
            db.Close();
            return numRowsEffected == 1;
        }
        if(RobotID > 0 && RobotMovieExist(RobotID))
        {
            int numRowsEffected = db.Execute("DELETE FROM RobotMovies WHERE RobotID = @0",
                RobotID);
            db.Close();
            return numRowsEffected > 0;
        }
        return false;
    }
    #endregion
    #region Delete Software
    public bool SoftwareExist(int ID)
    {
        Database db = Database.Open("Cyberdyne");
        var commandText = @"SELECT COUNT(*) FROM Software WHERE SoftwareID = @0";
        return (int)db.QueryValue(commandText, ID) > 0;
    }

    public bool RobotSoftwareExist(int RobotID)
    {
        Database db = Database.Open("Cyberdyne");
        var commandText = @"SELECT COUNT(*) FROM Software WHERE RobotID = @0";
        return (int)db.QueryValue(commandText, RobotID) > 0;
    }

    public bool DeleteSoftwareFromDB(int SoftwareID = -1, int RobotID = -1)
    {
        Database db = Database.Open("Cyberdyne");
        if (RobotID == -1 && SoftwareExist(SoftwareID))
        {       
            int numRowsEffected = db.Execute("DELETE FROM Software WHERE SoftwareID = @0",
                SoftwareID);
             return numRowsEffected == 1;
        }
        if (RobotID > 0 && RobotSoftwareExist(RobotID))
        {
            int numRowsEffected = db.Execute("DELETE FROM Software WHERE RobotID = @0",
                RobotID);
            return numRowsEffected > 0;
        }
        return false;
     }
    #endregion
    #region Delete Supplier
    public bool DeleteSupplierFromDB(int SupplierID)
    {
        Database db = Database.Open("Cyberdyne");
        int numRowsEffected = db.Execute("DELETE FROM Supplier WHERE SupplierID = @0",
            SupplierID);
        db.Close();
        return numRowsEffected > 0;
    }
    #endregion
    #region Delete Robot
    public bool DeleteRobotFromDB(int RobotID)
    {
        Database db = Database.Open("Cyberdyne");
        int numRowsEffected = db.Execute("DELETE FROM ComponentList WHERE RobotID = @0",
            RobotID);
        bool[] deleteTrue = new bool[4];
        deleteTrue[0] = DeleteFilesFromDB(-1, RobotID);
        deleteTrue[1] = DeleteImageFromDB(-1, RobotID);
        deleteTrue[2] = DeleteMovieFromDB(-1, RobotID);
        deleteTrue[3] = DeleteSoftwareFromDB(-1, RobotID);
        //for (int i = 0; i < deleteTrue.Length; i++)
        //{
        //    if (!deleteTrue[i])
        //    {
        //        return false;
        //    }
        //}
        int numRowsEffected2 = db.Execute("DELETE FROM Robots WHERE RobotID = @0",
            RobotID);
        db.Close();
        return numRowsEffected > 0 && numRowsEffected2 == 1;
    }
    #endregion

}
