using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public PhotonView photonView;
    public GameObject playerCamera;
    public TextMeshProUGUI interactableText;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable") {
            Debug.Log("has tocado el objeto");
            interactableText.gameObject.SetActive(true);
            interactableText.enabled = true;

            interactableText.text = "sdfsfd";
            WaitFor2Sec();
            interactableText.gameObject.SetActive(false);

        }
    }

    IEnumerator WaitFor2Sec() {
        yield return new WaitForSeconds(3);


    }
}


