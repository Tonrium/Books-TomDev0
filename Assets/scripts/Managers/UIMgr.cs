using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// 层级枚举
/// </summary>
public enum E_UILayer
{
    /// <summary>
    /// 最底层
    /// </summary>
    Bottom,
    /// <summary>
    /// 中层
    /// </summary>
    Middle,
    /// <summary>
    /// 高层
    /// </summary>
    Top,
    /// <summary>
    /// 系统层 最高层
    /// </summary>
    System,
}

/// <summary>
/// 管理所有UI面板的管理器
/// 注意：面板预设体名要和面板类名一致！！！！！
/// </summary>
public class UIMgr : BaseManager<UIMgr>
{
    private Camera uiCamera;
    private Canvas uiCanvas;
    private EventSystem uiEventSystem;

    //层级父对象
    private Transform bottomLayer;
    private Transform middleLayer;
    private Transform topLayer;
    private Transform systemLayer;

    /// <summary>
    /// 用于存储所有的面板对象
    /// </summary>
    private Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();

    public UIMgr()
    {
        //动态创建唯一的Canvas和EventSystem（摄像机）
        uiCamera = GameObject.Instantiate(ResMgr.Instance.Load<GameObject>("UI/UICamera")).GetComponent<Camera>();
        //ui摄像机过场景不移除 专门用来渲染UI面板
        GameObject.DontDestroyOnLoad(uiCamera.gameObject);

        //动态创建Canvas
        uiCanvas = GameObject.Instantiate(ResMgr.Instance.Load<GameObject>("UI/Canvas")).GetComponent<Canvas>();
        //设置使用的UI摄像机
        uiCanvas.worldCamera = uiCamera;
        //过场景不移除
        GameObject.DontDestroyOnLoad(uiCanvas.gameObject);

        //找到层级父对象
        bottomLayer = uiCanvas.transform.Find("Bottom");
        middleLayer = uiCanvas.transform.Find("Middle");
        topLayer = uiCanvas.transform.Find("Top");
        systemLayer = uiCanvas.transform.Find("System");

        //动态创建EventSystem
        uiEventSystem = GameObject.Instantiate(ResMgr.Instance.Load<GameObject>("UI/EventSystem")).GetComponent<EventSystem>();
        GameObject.DontDestroyOnLoad(uiEventSystem.gameObject);
    }

    /// <summary>
    /// 获取对应层级的父对象
    /// </summary>
    /// <param name="layer">层级枚举值</param>
    /// <returns></returns>
    public Transform GetLayerFather(E_UILayer layer)
    {
        switch (layer)
        {
            case E_UILayer.Bottom:
                return bottomLayer;
            case E_UILayer.Middle:
                return middleLayer;
            case E_UILayer.Top:
                return topLayer;
            case E_UILayer.System:
                return systemLayer;
            default:
                return null;
        }
    }

    /// <summary>
    /// 显示面板
    /// </summary>
    /// <typeparam name="T">面板的类型</typeparam>
    /// <param name="layer">面板显示的层级</param>
    /// <param name="callBack">由于可能是异步加载 因此通过委托回调的形式 将加载完成的面板传递出去进行使用</param>
    /// <param name="isSync">是否采用同步加载 默认为false</param>
    public void ShowPanel<T>(E_UILayer layer = E_UILayer.Middle, UnityAction<T> callBack = null, bool isSync = false) where T:BasePanel
    {
        //获取面板名 预设体名必须和面板类名一致 
        string panelName = typeof(T).Name;
        //存在面板
        if(panelDic.ContainsKey(panelName))
        {
            //如果要显示面板 会执行一次面板的默认显示逻辑
            panelDic[panelName]?.ShowMe();
            //如果存在回调 直接返回出去即可
            callBack?.Invoke(panelDic[panelName] as T);
            return;
        }

        //不存在面板 加载面板
        ABResMgr.Instance.LoadResAsync<GameObject>("UI", panelName, (res) =>
        {
            //层级的处理
            Transform father = GetLayerFather(layer);
            //避免没有按指定规则传递层级参数 避免为空
            if (father == null)
                father = middleLayer;
            //将面板预设体创建到对应父对象下 并且保持原本的缩放大小
            GameObject panelObj = GameObject.Instantiate(res, father, false);

            //获取对应UI组件返回出去
            T panel = panelObj.GetComponent<T>();
            //显示面板时执行的默认方法
            panel?.ShowMe();
            //传出去使用
            callBack?.Invoke(panel);
            //存储panel
            panelDic.Add(panelName, panel);

        }, isSync);
    }

    /// <summary>
    /// 隐藏面板
    /// </summary>
    /// <typeparam name="T">面板类型</typeparam>
    public void HidePanel<T>() where T : BasePanel
    {
        string panelName = typeof(T).Name;
        if(panelDic.ContainsKey(panelName))
        {
            //执行默认的隐藏面板想要做的事情
            panelDic[panelName]?.HideMe();
            //销毁面板
            GameObject.Destroy(panelDic[panelName].gameObject);
            //从容器中移除
            panelDic.Remove(panelName);
        }
    }

    /// <summary>
    /// 获取面板
    /// </summary>
    /// <typeparam name="T">面板的类型</typeparam>
    public T GetPanel<T>() where T:BasePanel
    {
        string panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
            return panelDic[panelName] as T;
        return null;
    }
    public void wakeUp()
    {
        //用于在不需要任何处理时生成UIMgr实例
    }
}
