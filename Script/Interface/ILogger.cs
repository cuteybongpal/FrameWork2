using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILogger
{
    public void Log(string message);
    public void Error(string message);
}
