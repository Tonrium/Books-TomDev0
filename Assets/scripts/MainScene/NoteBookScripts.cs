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
        // 保存原始的缩放比例
        image = GetComponent<Image>();
        originalScale = image.transform.localScale;
        print("0");
    }

    // 当鼠标进入时调用
    public void OnPointerEnter(PointerEventData eventData)
    {
        // 图片放大10%
        image.transform.localScale = originalScale * 1.1f;
        print("1");
    }

    // 当鼠标离开时调用
    public void OnPointerExit(PointerEventData eventData)
    {
        // 恢复到原始大小
        image.transform.localScale = originalScale;
        print("2");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // 这里是点击后执行的逻辑
        EventCenter.Instance.EventTrigger("TapNoteBook");
        print("Image clicked");
    }
}
