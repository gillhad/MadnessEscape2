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

    GameObject player;

    public float distance;
    public float maxDistance = 5f;




    [SerializeField]
    public float mouseSensibility = 50;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        
    }


    void OnMouseDown()
    {

        distance = Vector3.Distance(player.transform.position, transform.position);

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

        if (distance < maxDistance)
        {
            transform.position = GetMouseWorldPos()
            + mOffset;
            ;

        }


    }

}
