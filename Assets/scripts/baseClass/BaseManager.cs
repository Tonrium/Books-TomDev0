using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ģʽ���� ��ҪĿ���Ǳ����������� ��������ʵ�ֵ���ģʽ����
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseManager<T> where T:class,new()
{
    public static T instance;

    //���Եķ�ʽ
    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = new T();
            return instance;
        }
    }

    //�����ķ�ʽ
    //public static T GetInstance()
    //{
    //    if (instance == null)
    //        instance = new T();
    //    return instance;
    //}
}
