using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System.Diagnostics;

public class Logger : ILogger
{
    public async Task Error(string message)
    {
        //tood: ���� �� ���� FireBase�� �ø��� ��� �����(������)
        UnityEngine.Debug.LogError(message);
    }

    public async Task Invoke<T>(IRequest<T> request)
    {
        
    }

    public async Task Log(string message)
    {
        //tood: CPU��뷮 GPU��뷮�� �� ������ �ø��� ��� �����(������ ��)
        UnityEngine.Debug.Log(message);
    }
    public async Task StartLogging<T>(Func<Task> action, IRequest<T> request)
    {
        try
        {
            Stopwatch sw = Stopwatch.StartNew();

            await action.Invoke();
            sw.Stop();
            await Log($"{request} Successed! \n ElapsedTime : {sw.ElapsedMilliseconds}ms");
        }
        catch(Exception e)
        {
            await Error($"{request} Failed: {e.ToString()}");
        }

    }
}
