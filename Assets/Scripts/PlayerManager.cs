using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviour
{
    public PhotonView photonView;
    public GameObject playerCamera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.InRoom && !photonView.IsMine)
        {
            playerCamera.gameObject.SetActive(false);
            return;
        }
        
        
    }

    public void CameraShake() {
        playerCamera.transform.localRotation = Quaternion.Euler(Random.Range(-2f, 2f),0,0);

    }
}


