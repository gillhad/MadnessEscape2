using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnDrag3D : MonoBehaviour
   // ,IBeginDragHandler, IEndDragHandler, IDragHandler
{
    GameManager gameManager;
    private RectTransform rectTransform;
    private Vector3 currentPos;
    private Vector3 velocity = Vector3.zero;
    private Vector3 mOffset;
    float mZcord;
    private Transform currentPos3D;
    private GameObject thisGameObject;
    //private Vector3 PotionPosition = new Vector3();
    //public Text text;

    private CanvasGroup canvasGroup;
    [SerializeField]
    private float dampingSpeed = 0.3f;

    private void Awake()
    {
        //rectTransform = transform as RectTransform;
        //currentPos = rectTransform.transform.position;
        //canvasGroup = GetComponent<CanvasGroup>();
        

    }

    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    currentPos3D = GetComponent<Transform>();
    //    Debug.Log(currentPos3D.position.x);
    //}

    //public void OnDrag(PointerEventData eventData)
    //{
    //    if (RectTransformUtility.ScreenPointToWorldPointInRectangle(
    //        rectTransform,
    //        eventData.position,
    //        eventData.pressEventCamera,
    //        out var globalmMousePosition))
    //    {
    //        rectTransform.position = Vector3.SmoothDamp(rectTransform.transform.position,
    //            globalmMousePosition,
    //            ref velocity, dampingSpeed);
    //    }
    //    rectTransform.anchoredPosition += eventData.delta;
    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    Debug.Log("soltando");
    //    canvasGroup.alpha = 1f;
    //    canvasGroup.blocksRaycasts = true;
    //    Time.timeScale = 1;
    //}

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0)) {
    //        if (thisGameObject == null)
    //        {
    //            RaycastHit hit = CastRay();

    //            if (hit.collider != null) {
    //                if (!hit.collider.CompareTag("Draggable")){
    //                    return;
    //                }
    //                Debug.Log("tocas un objeto dragable");
    //                thisGameObject = hit.collider.gameObject;
    //                Cursor.visible = false;
    //            }
    //        }
    //        else { 

    //        }
    //    }

    //    if (thisGameObject != null) {
    //        Vector3 position = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.WorldToScreenPoint(thisGameObject.transform.position).z);
    //        Vector3 worldPos = Camera.main.ScreenToWorldPoint(position);
    //        thisGameObject.transform.position = new Vector3(worldPos.x, .25f, worldPos.z);

    //    }
    //}

    //private RaycastHit CastRay() {
    //    Debug.Log(Input.mousePosition.x);
    //    Debug.Log(Camera.main.farClipPlane);
    //    Vector3 screenousePosFar = new Vector3(
    //        Input.mousePosition.x,
    //        Input.mousePosition.y,
    //        Camera.main.farClipPlane
    //        );
    //    Debug.Log(Camera.main.farClipPlane);
    //    Vector3 screenousePosNear = new Vector3(
    //        Input.mousePosition.x,
    //        Input.mousePosition.y,
    //       Camera.main.nearClipPlane
    //        );

    //    Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenousePosFar);
    //    Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenousePosNear);
    //    RaycastHit hit;
    //    Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear,out hit,100f);

    //    return hit;

    //}

    void OnMouseDown()
    {
        Debug.Log("mouse has been pressed");
        Debug.Log(gameObject.name);
        mZcord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();

    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZcord;
        
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }
}
