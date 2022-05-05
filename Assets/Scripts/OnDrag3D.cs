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
    
    
    }

    void OnMouseDown()
    {
        mZcord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Debug.Log(mZcord);
        mOffset = gameObject.transform.position - GetMouseWorldPos();

    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y,transform.position.z);
        mousePoint.z = mZcord;
        
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos()
            + mOffset;
            ;
    }
}
