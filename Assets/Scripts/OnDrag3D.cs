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

  //  GameObject player = GameObject.Find("FPSPlayer");

    public float distance;
    



    
    [SerializeField] 
    public float mouseSensibility = 50;
  

    
  

    void OnMouseDown()
    {
      //  distance = Vector3.Distance(player.transform.position, transform.position);
        
            
       /* if (distance < )
        {
            
        }*/

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
