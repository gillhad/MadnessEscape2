using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class PotionPuzze : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler,IDragHandler,IDropHandler
{
    GameManager gameManager;
    private RectTransform rectTransform;
    private Vector3 currentPos;
    private Vector3 velocity = Vector3.zero;
    private Vector3 PotionPosition = new Vector3();
    public Text text;

    int currentMl;

    private CanvasGroup canvasGroup;
    [SerializeField]
    private float dampingSpeed = 0.3f;
    private void Awake()
    {
        rectTransform = transform as RectTransform;
        currentPos = rectTransform.transform.position;
        canvasGroup = GetComponent<CanvasGroup>();
        Debug.Log("cambiar pocion");
        if (GetComponentInChildren<Text>().text != "0")
        {
            Debug.Log("está llena");
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/GreenPotion");
        }
        else {
            Debug.Log("Está vacia");
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/EmptyPotion");
        }
        //currentMl = int.Parse(rectTransform.name);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .5f;
        canvasGroup.blocksRaycasts = false;
        //Debug.Log("has cogido la botella de "+currentMl+"litros");

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
        //if(eventData.position.x)
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        rectTransform.transform.position = currentPos;
    }

    public void OnPointerDown(PointerEventData eventData) { 
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        /*Debug.Log("droped");
        if(eventData.pointerDrag!= null){
            Debug.Log(eventData.pointerDrag.GetComponentInChildren<Text>().text);
            if (eventData.pointerDrag.name == "5L") { 

            }
        }*/
    }
}
