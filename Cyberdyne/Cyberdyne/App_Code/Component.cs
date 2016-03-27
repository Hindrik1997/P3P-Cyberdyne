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
    public string componentName { get; set; }
    public decimal price { get; set; }
    public string descriptionNL { get; set; }
    public string descriptionENG { get; set; }

    public int robotID { get; set; }
    public string robotName { get; set; }
    public int supplierID { get; set; }
    public int componentQuantity { get; set; }

    public List<ComponentData> components { get; set; }
    public Supplier referencedSupplier { get; private set; }


    public Component(string componentNumber, string componentName, decimal price, int _ID, RepoManager _RepoRef, int robotID = -1, string robotName = null, int componentQuantity = -1, int supplierID = -1) : base(_ID,_RepoRef)
    {
        this.componentNumber = componentNumber;
        this.price = price;
        this.componentName = componentName;
        this.robotID = robotID;
        this.robotName = robotName;
        this.componentQuantity = componentQuantity;
        this.supplierID = supplierID;
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
        IEnumerable<dynamic> result = db.Query("SELECT * FROM ComponentList WHERE ComponentID = @0", ID);
        components = new List<ComponentData>();

        foreach (var Item in result)
        {
            //ComponentID ophalen en zoeken naar bijhorende component en deze aan de componentlijst toevoegen
            foreach (Component P in repoRef.componentRepository)
            {
                if (P.ID == (int)Item["ComponentID"])
                {
                    components.Add(new ComponentData(P, (int)Item["Quantity"], Item["RobotID"]));
                    break;
                }
            }
        }
    }

    public override void UpdateData()
    {
        Database db = Database.Open("Cyberdyne");
        bool exist = Exist();

        if (exist)
            db.Execute("UPDATE Components SET ComponentNumber=@0, SupplierID=@1, Price=@2, DescriptionNL=@3, DescriptionENG=@4, ComponentName=@5 WHERE ComponentID =@6",componentNumber, supplierID, price, descriptionNL, descriptionENG, ID);
        else
        {
            db.Execute("INSERT INTO Components (ComponentNumber, SupplierID, Price, DescriptionNL, DescriptionENG, ComponentName) VALUES @0, @1, @2, @3, @4, @5", componentNumber, supplierID, price, descriptionNL, descriptionENG);
            ID = db.QueryValue("SELECT ComponentID FROM Components WHERE ComponentID = @@IDENTITY");
        }
        db.Close();
    }
    public bool Exist()
    {
        Database db = Database.Open("Cyberdyne");
        var commandText = @"SELECT COUNT(*) FROM Components WHERE ComponentID = @0";
        return (int)db.QueryValue(commandText, ID) > 0;
    }
}