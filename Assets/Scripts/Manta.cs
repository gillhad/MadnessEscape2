using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Manta : MonoBehaviour
{

    public GameObject baul;

    public GameObject sword;
    public GameObject cloth;

    Collider baulCollider;

    void Start(){
        baulCollider = baul.GetComponent<BoxCollider>();
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.name =="sword_a")
        {
            cloth.SetActive(false);
            baulCollider.enabled = true;           
        }
        
    }

    void OnTriggerExit(Collider other){

    }
}
