using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : ILogger
{
    public void Log(string message)
    {
        Debug.Log(message);
    }
    public void Error(string message)
    {
        Debug.Log(message);
    }
    
}
