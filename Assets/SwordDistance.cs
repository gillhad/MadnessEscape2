using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDistance : MonoBehaviour
{
    GameObject player;
    public float pos;
    Vector3 startPos;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Awake()
    {
        startPos = this.transform.position;
    }

    void Update()
    {
        pos = Vector3.Distance(player.transform.position, transform.position);

        if (this.transform.position.z < 0 || this.transform.position.z > 13.5 ||
            this.transform.position.x < 14.5 || this.transform.position.x > 24.5 ||
            this.transform.position.y < 0 || this.transform.position.y > 4)

            if (this.transform.position.z < 5.5 || this.transform.position.z > 13.5 ||
                this.transform.position.x < 14.5 || this.transform.position.x > 19 ||
                this.transform.position.y < 0 || this.transform.position.y > 4)
            {
                this.transform.position = startPos;
            }
        {
            
        }

    }
}