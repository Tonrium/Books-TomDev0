using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Resources ��Դ����ģ�������
/// </summary>
public class ResMgr : BaseManager<ResMgr>
{
    public ResMgr() { }

    /// <summary>
    /// ͬ������Resources����Դ�ķ���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    public T Load<T>(string path) where T : UnityEngine.Object
    {
        return Resources.Load<T>(path);
    }

    /// <summary>
    /// �첽������Դ�ķ���
    /// </summary>
    /// <typeparam name="T">��Դ����</typeparam>
    /// <param name="path">��Դ·����Resources�µģ�</param>
    /// <param name="callBack">���ؽ�����Ļص����� ���첽������Դ������Ż����</param>
    public void LoadAsync<T>(string path, UnityAction<T> callBack) where T: UnityEngine.Object
    {
        //Ҫͨ��Эͬ����ȥ�첽������Դ
        MonoMgr.Instance.StartCoroutine(ReallyLoadAsync<T>(path, callBack));
    }

    private IEnumerator ReallyLoadAsync<T>(string path, UnityAction<T> callBack) where T : UnityEngine.Object
    {
        //�첽������Դ
        ResourceRequest rq = Resources.LoadAsync<T>(path);
        //�ȴ���Դ���ؽ����� �Ż����ִ��yield return����Ĵ���
        yield return rq;
        //��Դ���ؽ��� ����Դ�����ⲿ��ί�к���ȥ����ʹ��
        callBack(rq.asset as T);
    }

    /// <summary>
    /// �첽������Դ�ķ���
    /// </summary>
    /// <param name="path">��Դ·����Resources�µģ�</param>
    /// <param name="callBack">���ؽ�����Ļص����� ���첽������Դ������Ż����</param>
    public void LoadAsync(string path, Type type, UnityAction<UnityEngine.Object> callBack) 
    {
        //Ҫͨ��Эͬ����ȥ�첽������Դ
        MonoMgr.Instance.StartCoroutine(ReallyLoadAsync(path, type, callBack));
    }

    private IEnumerator ReallyLoadAsync(string path, Type type, UnityAction<UnityEngine.Object> callBack)
    {
        //�첽������Դ
        ResourceRequest rq = Resources.LoadAsync(path, type);
        //�ȴ���Դ���ؽ����� �Ż����ִ��yield return����Ĵ���
        yield return rq;
        //��Դ���ؽ��� ����Դ�����ⲿ��ί�к���ȥ����ʹ��
        callBack(rq.asset);
    }

    /// <summary>
    /// ָ��ж��һ����Դ
    /// </summary>
    /// <param name="assetToUnload"></param>
    public void UnloadAsset(UnityEngine.Object assetToUnload)
    {
        Resources.UnloadAsset(assetToUnload);
    }

    /// <summary>
    /// �첽ж�ض�Ӧû��ʹ�õ�Resources��ص���Դ
    /// </summary>
    /// <param name="callBack">�ص�����</param>
    public void UnloadUnusedAssets(UnityAction callBack)
    {
        MonoMgr.Instance.StartCoroutine(ReallyUnloadUnusedAssets(callBack));
    }

    private IEnumerator ReallyUnloadUnusedAssets(UnityAction callBack)
    {
        AsyncOperation ao = Resources.UnloadUnusedAssets();
        yield return ao;
        //ж����Ϻ� ֪ͨ�ⲿ
        callBack();
    }

}
