using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ComponentData
/// </summary>
public class ComponentData
{
    public Component component = null;
    public int count = 0;

    public ComponentData(Component _Component, int _Count)
    {
        component = _Component;
        count = _Count;
    }
}