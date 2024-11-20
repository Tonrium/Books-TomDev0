using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 单例模式基类 主要目的是避免代码的冗余 方便我们实现单例模式的类
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseManager<T> where T:class,new()
{
    public static T instance;

    //属性的方式
    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = new T();
            return instance;
        }
    }

    //方法的方式
    //public static T GetInstance()
    //{
    //    if (instance == null)
    //        instance = new T();
    //    return instance;
    //}
}
