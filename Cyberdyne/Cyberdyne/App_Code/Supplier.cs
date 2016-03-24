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
        throw new NotNecessaryException();
    }
    public override void UpdateData()
    {
        Database db = Database.Open("Cyberdyne");
        bool exist = false;
        foreach (var Supplier in RepoRef.SupplierRepository)
        {
            if (Supplier.ID == ID)
            {
                exist = true;
            }
        }
        if (exist)
            db.Execute("UPDATE Supplier SET Name=@0, Address=@1  WHERE CategoryId", name, address);
        else
            db.Execute("INSERT INTO Supplier (Name, Address) VALUES @0, @1", name, address);
    }
}