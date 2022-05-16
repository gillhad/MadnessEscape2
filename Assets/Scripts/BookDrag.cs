using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class BookDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [SerializeField] private Canvas canvas;
    private void Awake()
    {
        rectTransform = transform as RectTransform;
        canvasGroup = GetComponent<CanvasGroup>();
       
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("on begin drag");
        canvasGroup.alpha = .5f;
        canvasGroup.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //if(eventData.position.x)
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("eee");
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
