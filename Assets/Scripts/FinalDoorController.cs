using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorController : MonoBehaviour
{
    [SerializeField] Animator DoorController = null;

    public void OpenDoor(){
        DoorController.SetBool("OpenDoor", true);
    }
}
