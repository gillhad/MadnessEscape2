using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnDropItem3D : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {

        {
            eventData.pointerClick.transform.position = this.transform.position;
            Debug.Log("soltado en el sitio");
        }
        

    }
}
