using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NoteBookScripts : BasePanel, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
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
    public void OnPointerEnter(PointerEventData eventData)
    {
        // ͼƬ�Ŵ�10%
        image.transform.localScale = originalScale * 1.1f;
        print("1");
    }

    // ������뿪ʱ����
    public void OnPointerExit(PointerEventData eventData)
    {
        // �ָ���ԭʼ��С
        image.transform.localScale = originalScale;
        print("2");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // �����ǵ����ִ�е��߼�
        EventCenter.Instance.EventTrigger("TapNoteBook");
        print("Image clicked");
    }
}
