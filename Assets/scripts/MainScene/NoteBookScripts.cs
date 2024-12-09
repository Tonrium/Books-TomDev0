using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NoteBookScripts : BasePanel, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Image image;
    private Vector3 originalScale;
    public float scaleFactor = 1.1f;  // 放大的倍数
    public float duration = 1f;  // 动画持续时间

    void Start()
    {
        // 获取 Image 组件并保存原始缩放比例
        image = GetComponent<Image>();

        if (image == null)
        {
            Debug.LogError("Image component not found on the GameObject.");
            return; // 如果没有找到 Image 组件，终止执行
        }

        originalScale = image.transform.localScale;
    }

    // 当鼠标进入时调用
    public void OnPointerEnter(PointerEventData eventData)
    {
        // 启动动画：放大
        StopAllCoroutines();  // 停止任何现有的动画
        StartCoroutine(ScaleImage(image.transform.localScale, originalScale * scaleFactor, duration));
    }

    // 当鼠标离开时调用
    public void OnPointerExit(PointerEventData eventData)
    {
        // 启动动画：恢复原始大小
        StopAllCoroutines();  // 停止任何现有的动画
        StartCoroutine(ScaleImage(image.transform.localScale, originalScale, duration));
    }

    // 当鼠标点击时调用
    public void OnPointerClick(PointerEventData eventData)
    {
        // 这里是点击后执行的逻辑
        EventCenter.Instance.EventTrigger("TapNoteBook");
        print("Image clicked");
    }

    // Coroutine 实现平滑过渡
    private IEnumerator ScaleImage(Vector3 fromScale, Vector3 toScale, float duration)
    {
        float timeElapsed = 0;

        // 按照 duration 的比例计算每一帧的缩放
        while (timeElapsed < duration)
        {
            // 使用 Lerp 来平滑过渡
            image.transform.localScale = Vector3.Lerp(fromScale, toScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;  // 增加已过的时间
            yield return null;  // 等待下一帧
        }

        // 确保最终大小为目标大小
        image.transform.localScale = toScale;
    }
}
