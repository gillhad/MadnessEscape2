using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MouseLook : MonoBehaviour
{
    public PhotonView photonView;

    public float mouseSensibility = 50;
    public Transform playerBody;

    private float xRotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (PhotonNetwork.InRoom && !photonView.IsMine)
        {
            return;
        }

        float mouseX = Input.GetAxis("Mouse X")*mouseSensibility * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*mouseSensibility * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerBody.Rotate(Vector3.up * mouseX);
        
       transform.localRotation = Quaternion.Euler(xRotation,0,0);
          
    }
}
