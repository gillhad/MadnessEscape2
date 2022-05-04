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
    public GameObject primeraPista;
    public GameObject segundaPista;
    public GameObject terceraPista;



    void Update()
    {
        
        if (PhotonNetwork.InRoom && !photonView.IsMine)
        {
            playerCamera.gameObject.SetActive(false);
            return;
        }
        
    }

    //prueba para mover la c�mara cuando pase algo **pendiente de revisar**
    public void CameraShake() {
        playerCamera.transform.localRotation = Quaternion.Euler(Random.Range(-2f, 2f),0,0);

    }



    private void OnTriggerEnter(Collider other)
    {

        //Ejemplo de collider
        if(other.gameObject.name == "ArmarioInteractua" && photonView.IsMine) //nombre del objeto con el que interactuamos
        {
            interactableText.gameObject.SetActive(true);  //activamos el text del canvas principal
            interactableText.text = "PALOMITAS!!!"; //mensaje que vamos a mostrar
                
            StartCoroutine(WaitFor2Sec(playerCanvas)); // en este caso desactivamos el canvas tras mostrar el mensaje
        }
        
        if(other.gameObject.name == "BookLock" && photonView.IsMine && GameManager.lock1CanBeSeen) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerLockMenu.SetActive(true);
        }

        if(other.gameObject.tag == "Door") {
            Debug.Log("tocando puerta");
            GameObject door = other.gameObject; 
            gameManager.OpenDoor(door);
        }


        //mostrar el papel de bienvenida al jugador, solo el que lo ha triggereado
        if(other.gameObject.name == "Papel Bienvenida" && photonView.IsMine)
        {
            primeraPista.SetActive(true);
        }

        if(other.gameObject.name == "Primera Pista" && photonView.IsMine)
        {
            segundaPista.SetActive(true);
        }

        if(other.gameObject.name == "Tecera Pista(Clone)" && photonView.IsMine)
        {
            terceraPista.SetActive(true);
        }


        ///SALA 3
        if (other.gameObject.name == "Papel prueba" && photonView.IsMine )
        {
            gameManager.potionCanvas.SetActive(true);
            gameManager.OnPause();
        }

        if (other.gameObject.tag == "Interactable" && photonView.IsMine) {
            Debug.Log("tocas un objecto que interactúa");
            Cursor.visible = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //quitar el canvas de papel de bienvenida cuando salga del collider
        if (other.gameObject.name == "Papel Bienvenida" && photonView.IsMine)
        {
            primeraPista.SetActive(false);
        }
        if (other.gameObject.name == "BookLock" && photonView.IsMine)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            playerLockMenu.SetActive(false);
        }
        if (other.gameObject.name == "Primera Pista" && photonView.IsMine)
        {
            segundaPista.SetActive(false);
        }
        if (other.gameObject.name == "Tecera Pista(Clone)" && photonView.IsMine)
        {
            terceraPista.SetActive(false);
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


