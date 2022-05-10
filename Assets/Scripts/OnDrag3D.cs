using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;

public class OnDrag3D : MonoBehaviourPun
   // ,IBeginDragHandler, IEndDragHandler, IDragHandler
{
  
    private Vector3 mOffset;
    float mZcord;



    
    [SerializeField]
    private float dampingSpeed = 0.3f;    
    public float mouseSensibility = 50;
  

    
  

    void OnMouseDown()
    {
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
        transform.position = GetMouseWorldPos()
            + mOffset;
            ;

    }

}
