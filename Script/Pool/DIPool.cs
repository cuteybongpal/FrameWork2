using System;
using System.Collections.Generic;
using UnityEngine;

public class DIPool
{
    Dictionary<Type, Queue<IPool>> poolings = new Dictionary<Type, Queue<IPool>>();

    /// <summary>
    /// DI�� ��ϵ� ��ü�� ���� ������Ʈ Ǯ�� �޼����Դϴ�.
    /// 
    /// ����: ���׸� Ÿ�� T�� IPool ������ ���� ���� ������,
    /// IPool ������ �߰��� ��� DIContainer����
    /// - IPool�� ��ӹ��� ��ü
    /// - IPool�� ��ӹ��� ���� ��ü
    /// �� �����ϱ� ���� GetInstance �޼��带 ���� �����ؾ� �ϴ� ������ �Ǳ� �����Դϴ�.
    /// 
    /// ���� �� �޼���� Func&lt;IPool&gt;�� �޾� ���ο��� T�� ĳ�����ϸ�,
    /// ȣ�� �ÿ��� �ݵ�� T�� IPool�� ����Ѵٰ� ����ž� �մϴ�.
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
    //IPool ���� ������ ���� ���� ���� ���� ������ ������
    public void Return<T>(T element) where T : class
    {
        if (!poolings.ContainsKey(typeof(T)))
            poolings[typeof(T)] = new Queue<IPool>();

        poolings[typeof(T)].Enqueue(element as IPool);
    }
}
