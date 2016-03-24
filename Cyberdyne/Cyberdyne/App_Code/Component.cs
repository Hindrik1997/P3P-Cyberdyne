using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        throw new NotImplementedException();
    }
}