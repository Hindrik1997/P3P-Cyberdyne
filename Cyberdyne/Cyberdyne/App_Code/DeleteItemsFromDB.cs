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

    public bool DeleteComponentFromDB(int ComponentID)
    {
        Database db = Database.Open("Cyberdyne");
        int numRowsEffected = db.Execute("DELETE FROM ComponentList WHERE ComponentID = @0",
            ComponentID);

        int numRowsEffected2 = db.Execute("DELETE FROM Components WHERE ComponentID = @0",
            ComponentID);
        db.Close();
        return numRowsEffected > 0 && numRowsEffected2 == 1;

    }

    public bool DeleteComponentFromRobot(int ComponentID, int RobotID)
    {
        Database db = Database.Open("Cyberdyne");
        int numRowsEffected = db.Execute("DELETE FROM ComponentList WHERE ComponentID = @0 AND RobotID = @1",
            ComponentID, RobotID);
        db.Close();
        return numRowsEffected == 1;
    }

    public bool DeleteFilesFromDB(int FileID = -1, int RobotID = -1)
    {
        Database db = Database.Open("Cyberdyne");
        if (RobotID == -1)
        {
            int numRowsEffected = db.Execute("DELETE FROM Files WHERE FileID = @0",
            FileID);
            db.Close();
            return numRowsEffected == 1;
        }
        if (RobotID > 0)
        {
            int numRowsEffected = db.Execute("DELETE FROM Files WHERE RobotID = @0",
            FileID);
            db.Close();
            return numRowsEffected > 0;
        }
        else
            db.Close();
        return false;
    }

    public bool DeleteImageFromDB(int ImageID = -1, int RobotID = -1)
    {
        Database db = Database.Open("Cyberdyne");
        if (RobotID == -1)
        {
          int numRowsEffected = db.Execute("DELETE FROM RobotImages WHERE RobotImages = @0",
          ImageID);
          db.Close();
          return numRowsEffected == 1;
        }
        if(RobotID > 0)
        {
            int numRowsEffected = db.Execute("DELETE FROM RobotImages WHERE RobotID = @0",
            ImageID);
            db.Close();
            return numRowsEffected > 0;
        }
        else
            db.Close();
        return false;
    }

    public bool DeleteMovieFromDB(int MovieID = -1, int RobotID = -1)
    {
        Database db = Database.Open("Cyberdyne");
        if (RobotID == -1)
        {
            int numRowsEffected = db.Execute("DELETE FROM RobotMovies WHERE MovieID = @0",
                MovieID);
            db.Close();
            return numRowsEffected == 1;
        }
        if(RobotID > 0)
        {
            int numRowsEffected = db.Execute("DELETE FROM RobotMovies WHERE RobotID = @0",
                RobotID);
            db.Close();
            return numRowsEffected > 0;
        }
        else
            db.Close();
            return false;
    }

    public bool DeleteSoftwareFromDB(int SoftwareID = -1, int RobotID = -1)
    {
        Database db = Database.Open("Cyberdyne");
        if (RobotID == -1)
        {
            int numRowsEffected = db.Execute("DELETE FROM Software WHERE SoftwareID = @0",
                SoftwareID);
            db.Close();
            return numRowsEffected == 1;
        }
        if (RobotID > 0)
        {
            int numRowsEffected = db.Execute("DELETE FROM MovieID WHERE RobotID = @0",
                RobotID);
            db.Close();
            return numRowsEffected > 0;
        }
        else
            db.Close();
            return false;
     }
    public bool DeleteSupplierFromDB(int SupplierID)
    {
        Database db = Database.Open("Cyberdyne");

        int numRowsEffected = db.Execute("DELETE FROM Supplier WHERE SupplierID = @0",
            SupplierID);
        db.Close();
        return numRowsEffected > 0;
    }

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
        for (int i = 0; i < deleteTrue.Length; i++)
        {
            if (!deleteTrue[i])
            {
                return false;
            }
        }
        int numRowsEffected2 = db.Execute("DELETE FROM Robots WHERE RobotID = @0",
            RobotID);
        db.Close();
        return numRowsEffected > 0 && numRowsEffected2 == 1;

    }
}