using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDistance : MonoBehaviour
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

        if (this.transform.position.x > 24 || this.transform.position.x < 13.5 ||
            this.transform.position.z < 0 || this.transform.position.z > 13 ||
            this.transform.position.y < 0 || this.transform.position.y > 4)
        {
            this.transform.position = startPos;
        }
        if (this.transform.position.z < 5 && this.transform.position.x > 19)
        {
            this.transform.position = startPos;
        }

    }
}