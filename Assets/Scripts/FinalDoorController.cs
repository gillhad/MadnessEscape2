using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorController : MonoBehaviour
{
    [SerializeField] Animator DoorController;

    public void openDoor(){
        DoorController.SetBool("OpenDoor", true);
    }
}
