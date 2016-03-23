using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Robot
/// </summary>
public class Robot : RepoObject
{
    public string Naam { get; set; }

    public string Category { get; set; }

    public Software Software { get; set; }

    public Supplier Supplier { get; set; }

    public List<Component> Components { get; set; }

    public List<File> Files { get; set; }

    public List<RobotImage> Images { get; set; }

    public List<RobotMovie> Movies { get; set; }


    public Robot(string _Naam, string _Category, int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        Category = _Category;
        Naam = _Naam;
    }

    public override void GetObjectData()
    {
        
    }
    public override void UpdateData()
    {
        throw new NotImplementedException();
    }
}