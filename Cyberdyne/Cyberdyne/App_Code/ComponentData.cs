using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ComponentData
/// </summary>
public class ComponentData
{
    public Component Component = null;
    public int Count = 0;

    public ComponentData(Component _Component, int _Count)
    {
        Component = _Component;
        Count = _Count;
    }
}