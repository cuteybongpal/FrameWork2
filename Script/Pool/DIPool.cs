using System;
using System.Collections.Generic;
using UnityEngine;

public class DIPool
{
    Dictionary<Type, Queue<IPool>> poolings = new Dictionary<Type, Queue<IPool>>();

    //IPool을 T타입 제약 조건을 받지 않는 이유는
    //이것을 호출할 때 IPool을 상속받는 객체와 IPool을 상속받지 않는 객체 두개에 따라
    //메소드를 분리해야하는 문제를 해결하기 위해서임.
    public IPool Get<T>(Func<IPool> func) where T : class, IDependency
    {
        IPool pool = null;

        if (!poolings.ContainsKey(typeof(T)))
            poolings[typeof(T)] = new Queue<IPool>();

        if (poolings[typeof(T)].Count == 0)
            pool = func.Invoke();
        else
            pool = poolings[typeof(T)].Dequeue();

        return pool;
    }
    //IPool ���� ������ ���� ���� ���� ���� ������ ������
    public void Return<T>(T element) where T : class
    {
        if (!poolings.ContainsKey(typeof(T)))
            poolings[typeof(T)] = new Queue<IPool>();

        poolings[typeof(T)].Enqueue(element as IPool);
    }
}
