using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceControl : MonoBehaviour
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

        if (this.transform.position.z < 20 || this.transform.position.z > 28 ||
            this.transform.position.x < 0 || this.transform.position.x > 14 ||
            this.transform.position.y < 0 || this.transform.position.y > 4)
        {
            this.transform.position = startPos;
        }

    }
}
