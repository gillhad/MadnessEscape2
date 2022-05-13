using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca22 : MonoBehaviour
{
    public GameObject lever;

    public GameObject sword;
    
    private bool up;

    //inicializar la palanca hacia arriba
    void Start()
    {
        up = true;
        lever.transform.Rotate(-60f, 0f, 0f);
    }

    //cuando se pulse sobre la palanca se subira o se bajara, segun en el estado en el que esté
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0))
        {
            if(up){
                lever.transform.Rotate(120f, 0, 0f);
                up = false;
                sword.GetComponent<Rigidbody>().useGravity = true;
            }else if(!up)
            {
                
                lever.transform.Rotate(-120f, 0, 0f);
                up = true;
            }
        }
    }
}
