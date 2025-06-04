using System;
using System.Collections.Generic;
using UnityEngine;

public class DIPool
{
    Dictionary<Type, Queue<IPool>> poolings = new Dictionary<Type, Queue<IPool>>();


    public T Get<T>(Func<T> func) where T : class, IPool
    {
        T pool = null;

        if (!poolings.ContainsKey(typeof(T)))
            poolings[typeof(T)] = new Queue<IPool>();

        if (poolings[typeof(T)].Count == 0)
            pool = func.Invoke();
        else
            pool = poolings[typeof(T)].Dequeue() as T;

        return pool;
    }
    public void Return<T>(T element) where T : class, IPool
    {

    }
}
