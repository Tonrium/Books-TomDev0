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
        // 保存原始的缩放比例
        image = GetComponent<Image>();
        originalScale = image.transform.localScale;
        print("0");
    }

    // 当鼠标进入时调用
    public void IOnPointerEnter(PointerEventData eventData)
    {
        // 图片放大10%
        image.transform.localScale = originalScale * 1.1f;
        print("1");
    }

    // 当鼠标离开时调用
    public void IOnPointerExit(PointerEventData eventData)
    {
        // 恢复到原始大小
        image.transform.localScale = originalScale;
        print("2");
    }
}
