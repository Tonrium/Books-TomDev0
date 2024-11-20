using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// �¼�����ģ�� 
/// </summary>
public class EventCenter : BaseManager<EventCenter>
{
    //���ڼ�¼��Ӧ�¼� ������ ��Ӧ���߼�
    private Dictionary<string, UnityAction> eventDic = new Dictionary<string, UnityAction>();

    public EventCenter() { }

    /// <summary>
    /// �����¼� 
    /// </summary>
    /// <param name="eventName">�¼�����</param>
    public void EventTrigger(string eventName)
    {
        //���ڹ����ҵ��� ��֪ͨ����ȥ�����߼�
        if(eventDic.ContainsKey(eventName))
        {
            //ȥִ�ж�Ӧ���߼�
            eventDic[eventName]?.Invoke();
        }
    }

    /// <summary>
    /// ����¼�������
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="func"></param>
    public void AddEventListener(string eventName, UnityAction func)
    {
        //����Ѿ����ڹ����¼���ί�м�¼ ֱ����Ӽ���
        if (eventDic.ContainsKey(eventName))
            eventDic[eventName] += func;
        else
        {
            eventDic.Add(eventName, null);
            eventDic[eventName] += func;
        }
            
    }

    /// <summary>
    /// �Ƴ��¼�������
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="func"></param>
    public void RemoveEventListener(string eventName, UnityAction func)
    {
        if (eventDic.ContainsKey(eventName))
            eventDic[eventName] -= func;
    }

    /// <summary>
    /// ��������¼��ļ���
    /// </summary>
    public void Clear()
    {
        eventDic.Clear();
    }

    /// <summary>
    /// ���ָ��ĳһ���¼������м���
    /// </summary>
    /// <param name="eventName"></param>
    public void Claer(string eventName)
    {
        if (eventDic.ContainsKey(eventName))
            eventDic.Remove(eventName);
    }
}
