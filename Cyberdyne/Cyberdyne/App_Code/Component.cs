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

    public int supplierID { get; set; }

    public Supplier referencedSupplier { get; private set; }


    public Component(string componentNumber, decimal price, int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        this.componentNumber = componentNumber;
        this.price = price;
    }

    public override void GetObjectData()
    {
        Database db = Database.Open("Cyberdyne");

        dynamic TextNL = db.QueryValue("SELECT DescriptionNL FROM Components WHERE ComponentID = @0", ID);
        dynamic TextENG = db.QueryValue("SELECT DescriptionENG FROM Components WHERE ComponentID = @0", ID);

        descriptionNL = Convert.ToString(TextNL);
        descriptionENG = Convert.ToString(TextENG);

        dynamic SupID = db.QueryValue("SELECT SupplierID FROM Components WHERE ComponentID = @0", ID);
        supplierID = Convert.ToInt32(SupID);
        foreach (Supplier s in repoRef.supplierRepository)
        {
            if (s.ID == supplierID)
            {
                referencedSupplier = s;
                break;
            }
        }
    }

    public override void UpdateData()
    {
        throw new NotImplementedException();
    }
}