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
        //tood: 오류 난 것을 FireBase에 올리는 기능 만들기(언젠가)
        UnityEngine.Debug.LogError(message);
    }

    public async Task Invoke<T>(IRequest<T> request)
    {
        
    }

    public async Task Log(string message)
    {
        //tood: CPU사용량 GPU사용량을 웹 서버에 올리는 기능 만들기(언젠가 ㅋ)
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
