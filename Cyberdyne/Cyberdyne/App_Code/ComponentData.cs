using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for ComponentData
/// </summary>
public class ComponentData
{
    public Component component = null;
    public int count = 0;
    public int robotID = 0;

    public ComponentData(Component _Component, int _Count, int robotID= -1)
    {
        component = _Component;
        count = _Count;
        this.robotID = robotID;
    }

    public void UpdateData()
    {
        Database db = Database.Open("Cyberdyne");
        if (Exist(component.ID, robotID))
            db.Execute("UPDATE ComponentList SET ComponentID=@0, RobotID=@1, Quantity=@2 WHERE ComponentID=@0 AND RobotID=@1", component.ID, robotID, count);
        else
        {
            db.Execute("INSERT INTO ComponentList (ComponentID, RobotID, Quantity) VALUES (@0, @1, @2)", component.ID, robotID, count);
        }
        db.Close();
    }
    public bool Exist(int componentID, int robotID)
    {
        Database db = Database.Open("Cyberdyne");
        var commandText = @"SELECT COUNT(*) FROM ComponentList WHERE ComponentID = @0 AND RobotID = @1";
        return (int)db.QueryValue(commandText, componentID, robotID) > 0;
    }
}