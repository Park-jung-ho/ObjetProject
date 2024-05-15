using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScaleAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float scaleSpeed = 5f; // ũ�� ��ȭ �ӵ�
    public float maxScale = 1.2f; // �ִ� ũ��

    private RectTransform rectTransform;
    private Vector3 originalScale;
    private bool isScalingUp = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }

    void Update()
    {
        if (isScalingUp)
        {
            // ũ�⸦ ���������� �ø��ϴ�.
            rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, originalScale * maxScale, scaleSpeed * Time.deltaTime);

            // �ִ� ũ�⿡ �����ϸ� �� �̻� ũ�⸦ �ø��� �ʽ��ϴ�.
            if (rectTransform.localScale.x >= originalScale.x * maxScale)
            {
                isScalingUp = false;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isScalingUp = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Ŀ���� ����� ���� ũ��� ��� ���ư��ϴ�.
        rectTransform.localScale = originalScale;
        isScalingUp = false;
    }
}