using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for Supplier
/// </summary>
public class Supplier : RepoObject
{
    public string name { get; set; }
    public string address { get; set; }

    public Supplier(string name, string address, int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        this.name = name;
        this.address = address;  
    }

    public override void GetObjectData()
    {
        //throw new NotNecessaryException();
    }
    public override void UpdateData()
    {
        Database db = Database.Open("Cyberdyne");
        bool exist = Exist();

        if (exist)
            db.Execute("UPDATE Supplier SET Name=@0, Address=@1  WHERE CategoryId", name, address);
        else
            {
            db.Execute("INSERT INTO Supplier (Name, Address) VALUES @0, @1", name, address);
            ID = db.QueryValue("SELECT SupplierID FROM Supplier WHERE SupplierID = @@IDENTITY");
            }
        db.Close();
    }

    public bool Exist()
    {
        Database db = Database.Open("Cyberdyne");
        var commandText = @"SELECT COUNT(*) FROM Supplier WHERE SupplierID = @0";
        return (int)db.QueryValue(commandText, ID) > 0;
    }
}