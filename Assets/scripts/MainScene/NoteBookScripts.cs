using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NoteBookScripts : BasePanel, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Image image;
    private Vector3 originalScale;
    public float scaleFactor = 1.1f;  // �Ŵ�ı���
    public float duration = 1f;  // ��������ʱ��

    void Start()
    {
        // ��ȡ Image ���������ԭʼ���ű���
        image = GetComponent<Image>();

        if (image == null)
        {
            Debug.LogError("Image component not found on the GameObject.");
            return; // ���û���ҵ� Image �������ִֹ��
        }

        originalScale = image.transform.localScale;
    }

    // ��������ʱ����
    public void OnPointerEnter(PointerEventData eventData)
    {
        // �����������Ŵ�
        StopAllCoroutines();  // ֹͣ�κ����еĶ���
        StartCoroutine(ScaleImage(image.transform.localScale, originalScale * scaleFactor, duration));
    }

    // ������뿪ʱ����
    public void OnPointerExit(PointerEventData eventData)
    {
        // �����������ָ�ԭʼ��С
        StopAllCoroutines();  // ֹͣ�κ����еĶ���
        StartCoroutine(ScaleImage(image.transform.localScale, originalScale, duration));
    }

    // �������ʱ����
    public void OnPointerClick(PointerEventData eventData)
    {
        // �����ǵ����ִ�е��߼�
        EventCenter.Instance.EventTrigger("TapNoteBook");
        print("Image clicked");
    }

    // Coroutine ʵ��ƽ������
    private IEnumerator ScaleImage(Vector3 fromScale, Vector3 toScale, float duration)
    {
        float timeElapsed = 0;

        // ���� duration �ı�������ÿһ֡������
        while (timeElapsed < duration)
        {
            // ʹ�� Lerp ��ƽ������
            image.transform.localScale = Vector3.Lerp(fromScale, toScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;  // �����ѹ���ʱ��
            yield return null;  // �ȴ���һ֡
        }

        // ȷ�����մ�СΪĿ���С
        image.transform.localScale = toScale;
    }
}
