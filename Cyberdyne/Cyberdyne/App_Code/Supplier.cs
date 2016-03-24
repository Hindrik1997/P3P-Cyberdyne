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
        throw new NotImplementedException();
    }
}