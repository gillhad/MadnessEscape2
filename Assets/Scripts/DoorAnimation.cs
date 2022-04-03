using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{

    [SerializeField] private Animator animator = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            Debug.Log("la puerta se abre");
            animator.Play("OpenDoor",0,0.0f);
            Debug.Log("deberia abrirse");
        }
    }

}
