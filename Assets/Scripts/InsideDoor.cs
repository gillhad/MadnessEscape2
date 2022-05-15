using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideDoor : MonoBehaviour
{
    public Transform insideDoor;
    public GameObject key21;

    private bool enContacto = false;
    

    void OnTriggerEnter(Collider other){
        if (other.gameObject.name =="key_gold")
        {
            enContacto = true;
            this.GetComponent<AudioSource>().Play();
        }
    }

    void Update(){
        if (enContacto)
        {
            Debug.Log("llave");
            var newRot = Quaternion.RotateTowards(insideDoor.rotation, Quaternion.Euler(0.0f, 265.0f, 0.0f), Time.deltaTime * 250);
            insideDoor.rotation = newRot;
            key21.SetActive(false);
        }
    }
}
