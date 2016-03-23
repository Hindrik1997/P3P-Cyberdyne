using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NotNecessaryException
/// </summary>
public class NotNecessaryException : Exception
{
    public NotNecessaryException() : base("This code can be safely omitted, it is not necessary")
    {
    }
    public NotNecessaryException(string message) : base(message)
    {
    }
    public NotNecessaryException(string message, Exception inner) : base(message,inner)
    {
    }
}