using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manta : MonoBehaviour
{

    public GameObject sword;
    public GameObject cloth;
    void OnTriggerEnter(Collider other){
        if (other.gameObject.name =="sword_a")
        {
            cloth.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other){

    }
}
