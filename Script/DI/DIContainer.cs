using UnityEngine;
using System.Collections.Generic;
using System;

public static class DIContainer
{
    static Dictionary<Type, Func<IDependency>> bindedType = new Dictionary<Type, Func<IDependency>>();

    public static T GetInstance<T>() where T : class, IDependency
    {
        if (!bindedType.ContainsKey(typeof(T)))
        {
            Debug.Log("DIContainer에 등록되지 않은 객체입니다.");
            return default(T);
        }

        if (!typeof(IPool).IsAssignableFrom(typeof(T)))
            return bindedType[typeof(T)].Invoke() as T;

        return default(T);
    }
    public static void ReturnInstance<T>(ref T element) where T : class, IDependency
    {
        if (!typeof(IPool).IsAssignableFrom(typeof(T)))
        {
            element = null;
            return;
        }
    }

    public static void Bind<IKey>(Func<IKey> func) where IKey : class, IDependency
    {
        bindedType.Add(typeof(IKey), func);
    }
    
}
