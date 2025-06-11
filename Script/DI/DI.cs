using System.Collections.Generic;
using System;
using UnityEngine;

public class DI
{
    public static class DIContainer
    {
        static Dictionary<Type, Func<IDependency>> bindedType = new Dictionary<Type, Func<IDependency>>();
        static DIPool dIPool = new DIPool();
        public static T GetInstance<T>() where T : class, IDependency
        {
            if (!bindedType.ContainsKey(typeof(T)))
            {
                Debug.Log("DIContainer에 등록되지 않은 객체입니다.");
                return default(T);
            }

            if (!typeof(IPool).IsAssignableFrom(typeof(T)))
                return bindedType[typeof(T)].Invoke() as T;

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
    public static class MiddleWareDIContainer
    {
        static Dictionary<(string, Type), Func<IDependency>> bindedType = new Dictionary<(string, Type), Func<IDependency>>();
        static DIPool dIPool = new DIPool();
        public static T GetInstance<T>(string key) where T : class, IDependency
        {
            if (!bindedType.ContainsKey((key, typeof(T))))
            {
                Debug.Log("DIContainer에 등록되지 않은 객체입니다.");
                return default(T);
            }

            if (!typeof(IPool).IsAssignableFrom(typeof(T)))
                return bindedType[(key, typeof(T))].Invoke() as T;

            return dIPool.Get<T>(bindedType[(key, typeof(T))] as Func<IPool>) as T;
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

        public static void Bind<IKey>(Func<IKey> func, string key) where IKey : class, IDependency, IMiddleWare
        {
            bindedType.Add((key, typeof(IKey)), func);
        }

    }
}
