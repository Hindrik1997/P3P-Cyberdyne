using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RepoManager
/// </summary>
public class RepoManager
{
    public RepoManager()
    {
        RobotRepository = new Repository<Robot>(this);
        RobotMovieRepository = new Repository<RobotMovie>(this);
        RobotImageRepository = new Repository<RobotImage>(this);
        ComponentRepository = new Repository<Component>(this);
        FileRepository = new Repository<File>(this);
        SoftwareRepository = new Repository<Software>(this);
        SupplierRepository = new Repository<Supplier>(this);
    }

    private Repository<Robot> RobotRepository = null;
    private Repository<RobotMovie> RobotMovieRepository = null;
    private Repository<RobotImage> RobotImageRepository = null;

    private Repository<Component> ComponentRepository = null;
    private Repository<File> FileRepository = null;

    private Repository<Software> SoftwareRepository = null;
    private Repository<Supplier> SupplierRepository = null;

}