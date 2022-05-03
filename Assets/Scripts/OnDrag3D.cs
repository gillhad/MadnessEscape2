using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnDrag3D : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    GameManager gameManager;
    private RectTransform rectTransform;
    private Vector3 currentPos;
    private Vector3 velocity = Vector3.zero;
    private Vector3 PotionPosition = new Vector3();
    public Text text;

    private CanvasGroup canvasGroup;
    [SerializeField]
    private float dampingSpeed = 0.3f;

    private void Awake()
    {
        rectTransform = transform as RectTransform;
        currentPos = rectTransform.transform.position;
        canvasGroup = GetComponent<CanvasGroup>();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .5f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(
            rectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out var globalmMousePosition))
        {
            rectTransform.position = Vector3.SmoothDamp(rectTransform.transform.position,
                globalmMousePosition,
                ref velocity, dampingSpeed);
        }
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        Time.timeScale = 1;
    }
}
