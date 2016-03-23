using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Supplier
/// </summary>
public class Supplier : RepoObject
{
    public string name { get; set; }
    public string adress { get; set; }

    public Supplier(string name, string adress, int _ID, RepoManager _RepoRef) : base(_ID,_RepoRef)
    {
        this.name = name;
        this.adress = adress;  
    }

    public override void GetObjectData()
    {
        throw new NotImplementedException();
    }
    public override void UpdateData()
    {
        throw new NotImplementedException();
    }
}