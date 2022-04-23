using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject lever;
    public bool up = true;

    void Start()
    {
        lever.transform.Rotate(-60f, 0f, 0f);
    }
    // Start is called before the first frame update
    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0))
        {
            if(up){
                lever.transform.Rotate(120f, 0f, 0f);
                up = false;
            }else if(!up)
            {
                lever.transform.Rotate(-120f, 0f, 0f);
                up = true;
            }
        }
    }
}
