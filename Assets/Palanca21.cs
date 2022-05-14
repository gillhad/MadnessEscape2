using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca21 : MonoBehaviour
{
    public GameObject lever;
    public GameObject door21;
    public GameObject door22;

    

    
    static public bool up;

    //inicializar la palanca hacia arriba
    void Start()
    {
        up = true;
        lever.transform.Rotate(-60f, 0f, 0f);

    }

    //cuando se pulse sobre la palanca se subira o se bajara, segun en el estado en el que esté
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (up)
            {
                lever.transform.Rotate(120f, 0, 0f);
                up = false;
                
                door21.SetActive(false);
                door22.SetActive(false);

            }
            else if (!up)
            {

                lever.transform.Rotate(-120f, 0, 0f);
                up = true;
            }
        }
    }
}
