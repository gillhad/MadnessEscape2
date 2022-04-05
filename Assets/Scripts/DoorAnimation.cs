using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{

    public bool canBeOpened = false;


    [SerializeField] private Animator animator = null;

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.door1CanBeOpened) {
            Debug.Log("la puerta se abre");
            animator.Play("OpenDoor",0,0.0f);
            Debug.Log("deberia abrirse");
            Collider.Destroy(this);
        }
    }*/

    //Si la variable estatica de GameManager, door1CanBeOpened esta en true, procedemos a abrir la puerta
    private void Update(){
        if (GameManager.door1CanBeOpened) {
            Debug.Log("la puerta se abre");
            animator.Play("OpenDoor",0,0.0f);
            Debug.Log("deberia abrirse");
            Collider.Destroy(this);
        }
    }

}
