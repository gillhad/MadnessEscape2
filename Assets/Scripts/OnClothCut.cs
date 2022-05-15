using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClothCut : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.gameObject.name =="sword_a"){
            this.GetComponent<AudioSource>().Play();
        }
    }

}
