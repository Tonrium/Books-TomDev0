using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NoteBookScripts : BasePanel
{
    // Start is called before the first frame update
    private Image image;
    private Vector3 originalScale;

    void Start()
    {
        // ����ԭʼ�����ű���
        image = GetComponent<Image>();
        originalScale = image.transform.localScale;
        print("0");
    }

    // ��������ʱ����
    public void IOnPointerEnter(PointerEventData eventData)
    {
        // ͼƬ�Ŵ�10%
        image.transform.localScale = originalScale * 1.1f;
        print("1");
    }

    // ������뿪ʱ����
    public void IOnPointerExit(PointerEventData eventData)
    {
        // �ָ���ԭʼ��С
        image.transform.localScale = originalScale;
        print("2");
    }
}
