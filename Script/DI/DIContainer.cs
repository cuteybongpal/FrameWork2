using UnityEngine;
using System.Collections.Generic;
using System;

public static class DIContainer
{
    static Dictionary<Type, Func<IDependency>> bindedType = new Dictionary<Type, Func<IDependency>>();
    static DIPool dIPool = new DIPool();
    public static IDependency GetInstance<T>() where T : class, IDependency
    {
        if (!bindedType.ContainsKey(typeof(T)))
        {
            Debug.Log("DIContainer에 등록되지 않은 객체입니다.");
            return default(T);
        }

        if (!typeof(IPool).IsAssignableFrom(typeof(T)))
            return bindedType[typeof(T)].Invoke();

        return dIPool.Get<T>(bindedType[typeof(T)] as Func<IPool>) as T;
    }
    public static void ReturnInstance<T>(ref T element) where T : class, IDependency
    {
        if (!typeof(IPool).IsAssignableFrom(typeof(T)))
        {
            element = null;
            return;
        }
        dIPool.Return<T>(element);
    }

    public static void Bind<IKey>(Func<IKey> func) where IKey : class, IDependency
    {
        bindedType.Add(typeof(IKey), func);
    }
    
}
