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
    public GameObject playerCanvas;
    public GameObject playerLockMenu;

    //botones canvas lock
    public Button lock1;
    public Button lock2;
    public Button lock3;
    public Button lock4;
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
            if (other.gameObject.name == "ArmarioInteractua")
            {
                Debug.Log("has tocado el objeto");
                interactableText.gameObject.SetActive(true);
                interactableText.text = "PALOMITAS";
                Debug.Log("aquí debería estar activo");

                StartCoroutine(WaitFor2Sec(playerCanvas));
            } else if (other.gameObject.name == "BookLock") {
            playerLockMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            }
        
        


    }

   /*
    * Deshabilita el canvas que le pases tras 5 segundos
    * 
    * @param gameObject -> canvas
    */
    IEnumerator WaitFor2Sec(GameObject gameObject) {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);


    }

    /*
     * Configuracion botones para lock
     * 
     */
    
}


