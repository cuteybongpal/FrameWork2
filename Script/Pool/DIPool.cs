using System;
using System.Collections.Generic;
using UnityEngine;

public class DIPool
{
    Dictionary<Type, Queue<IPool>> poolings = new Dictionary<Type, Queue<IPool>>();

    /// <summary>
    /// DI에 등록된 객체를 위한 오브젝트 풀링 메서드입니다.
    /// 
    /// 주의: 제네릭 타입 T에 IPool 제약을 걸지 않은 이유는,
    /// IPool 제약을 추가할 경우 DIContainer에서
    /// - IPool을 상속받은 객체
    /// - IPool을 상속받지 않은 객체
    /// 를 구분하기 위해 GetInstance 메서드를 따로 정의해야 하는 구조가 되기 때문입니다.
    /// 
    /// 따라서 이 메서드는 Func&lt;IPool&gt;을 받아 내부에서 T로 캐스팅하며,
    /// 호출 시에는 반드시 T가 IPool을 상속한다고 보장돼야 합니다.
    /// </summary>
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
    //IPool 제약 조건을 넣지 않은 것은 위와 동일한 이유임
    public void Return<T>(T element) where T : class
    {
        if (!poolings.ContainsKey(typeof(T)))
            poolings[typeof(T)] = new Queue<IPool>();

        poolings[typeof(T)].Enqueue(element as IPool);
    }
}
