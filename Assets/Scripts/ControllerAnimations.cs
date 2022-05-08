using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAnimations : MonoBehaviour
{
    [SerializeField] Animator wallAnimationController;

    public void openWall()
    {
        wallAnimationController.SetBool("OpenWall", true);
    }
}
