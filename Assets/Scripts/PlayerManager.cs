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
    public GameManager gameManager;
    
    //UI
    public TextMeshProUGUI interactableText;
        ///botones canvas lock
    public Button lock1;
    public Button lock2;
    public Button lock3;
    public Button lock4;

    //GameObjects
    public GameObject playerCanvas;
    public GameObject playerLockMenu;



    void Update()
    {
        if (PhotonNetwork.InRoom && !photonView.IsMine)
        {
            playerCamera.gameObject.SetActive(false);
            return;
        }
        
        
    }

    //prueba para mover la cámara cuando pase algo **pendiente de revisar**
    public void CameraShake() {
        playerCamera.transform.localRotation = Quaternion.Euler(Random.Range(-2f, 2f),0,0);

    }



    private void OnTriggerEnter(Collider other)
    {

        //Ejemplo de collider
            if (other.gameObject.name == "ArmarioInteractua") //nombre del objeto con el que interactuamos
            {
                interactableText.gameObject.SetActive(true);  //activamos el text del canvas principal
                interactableText.text = "PALOMITAS!!!"; //mensaje que vamos a mostrar
                
                StartCoroutine(WaitFor2Sec(playerCanvas)); // en este caso desactivamos el canvas tras mostrar el mensaje
            }
        
            if (other.gameObject.name == "BookLock") {
            playerLockMenu.SetActive(true);
            gameManager.OnPause();
            }

        if (other.gameObject.tag == "Door") {
            Debug.Log("tocando puerta");
            GameObject door = other.gameObject; 
            gameManager.OpenDoor(door);
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

    
}


