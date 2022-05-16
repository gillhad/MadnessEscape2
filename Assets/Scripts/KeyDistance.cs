using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDistance : MonoBehaviour
{


    public float pos;
    Vector3 startPos;


    void Awake()
    {
        startPos = this.transform.position;
    }

    void Update()
    {

        if (this.transform.position.z < 0.2 || this.transform.position.z > 13.5 ||
            this.transform.position.x < -0.5 || this.transform.position.x > 9.5 ||
            this.transform.position.y < 0 || this.transform.position.y > 4)
        {
            this.transform.position = startPos;
        }
        if (this.transform.position.x > 4.4 && this.transform.position.z < 5.5)
        {
            this.transform.position = startPos;
        }

    }
}
