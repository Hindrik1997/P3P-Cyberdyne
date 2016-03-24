using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for Component
/// </summary>
public class Component : RepoObject
{
    public string componentNumber { get; set; }
    public decimal price { get; set; }
    public string descriptionNL { get; set; }
    public string descriptionENG { get; set; }

    public int robotID { get; set; }
    public int supplierID { get; set; }

    public Supplier ReferencedSupplier { get; private set; }


    public Component(string componentNumber, decimal price, string descriptionNL, string descriptionENG, int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        this.componentNumber = componentNumber;
        this.price = price;
        this.descriptionNL = descriptionNL;
        this.descriptionENG = descriptionENG;
    }

    public override void GetObjectData()
    {
        throw new NotNecessaryException();
    }

    public override void UpdateData()
    {
        Database db = Database.Open("Cyberdyne");
        bool componentExist = false;
        bool supplierExist = false;
        foreach (var Component in RepoRef.ComponentRepository)
        {
            if (Component.ID == ID)
            {
                componentExist = true;
            }
        }
        foreach (var Supplier in RepoRef.SupplierRepository)
        {
            if (Supplier.ID == supplierID)
            {
                supplierExist = true;
            }
        }
        if (exist)
        {

        }
            db.Execute("UPDATE Supplier SET Name=@0, Address=@1  WHERE CategoryId", name, address);
        else
            db.Execute("INSERT INTO Supplier (Name, Address) VALUES @0, @1", name, address);
    }
}