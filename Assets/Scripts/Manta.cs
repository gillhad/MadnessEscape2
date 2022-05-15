using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Manta : MonoBehaviour
{

    public GameObject baul;

    public GameObject sword;
    public GameObject cloth;
    AudioSource audio;

    Collider baulCollider;

    void Start(){
        baulCollider = baul.GetComponent<BoxCollider>();
        audio = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.name =="sword_a")
        {
            audio.Play();
            StartCoroutine(WaitFor2Sec());      
        }
        
    }

    void OnTriggerExit(Collider other){

    }

    IEnumerator WaitFor2Sec()
    {
        yield return new WaitForSeconds(2);
            cloth.SetActive(false);
            baulCollider.enabled = true;   

    }
}


