using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScaleAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float scaleSpeed = 5f; // 크기 변화 속도
    public float maxScale = 1.2f; // 최대 크기

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
            // 크기를 점진적으로 늘립니다.
            rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, originalScale * maxScale, scaleSpeed * Time.deltaTime);

            // 최대 크기에 도달하면 더 이상 크기를 늘리지 않습니다.
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
        // 커서가 벗어나면 원래 크기로 즉시 돌아갑니다.
        rectTransform.localScale = originalScale;
        isScalingUp = false;
    }
}