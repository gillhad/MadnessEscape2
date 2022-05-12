using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using MadnessEscape2.Assets.Scripts;
using TMPro;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class PlayerManager : MonoBehaviourPun
{
    public PhotonView photonView;
    public GameObject playerCamera;
    private GameManager gameManager;

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

    public GameObject canvasdrawer;

    public GameObject PistaLetras;

    GameObject sword;
    GameObject ventana;
    GameObject sword2;


    bool drawerSolved = false;



    RaiseEventOptions options = new RaiseEventOptions()
    {
        CachingOption = EventCaching.DoNotCache,
        Receivers = ReceiverGroup.All
    };


    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = gameManager = FindObjectOfType<GameManager>();
        }

        if (sword == null)
        {
            sword = GameObject.FindGameObjectWithTag("EspadaA");
        }
        ventana = GameObject.FindGameObjectWithTag("VentanaClave");
        sword2 = GameObject.FindGameObjectWithTag("EspadaB");
    }
    void Update()
    {

        if (PhotonNetwork.InRoom && !photonView.IsMine)
        {
            playerCamera.gameObject.SetActive(false);
            return;
        }

    }

    //prueba para mover la c�mara cuando pase algo **pendiente de revisar**
    public void CameraShake()
    {
        playerCamera.transform.localRotation = Quaternion.Euler(Random.Range(-2f, 2f), 0, 0);

    }



    private void OnTriggerEnter(Collider other)
    {

        //Ejemplo de collider
        if (other.gameObject.name == "ArmarioInteractua" && photonView.IsMine) //nombre del objeto con el que interactuamos
        {
            interactableText.gameObject.SetActive(true);  //activamos el text del canvas principal
            interactableText.text = "PALOMITAS!!!"; //mensaje que vamos a mostrar

            StartCoroutine(WaitFor2Sec(playerCanvas)); // en este caso desactivamos el canvas tras mostrar el mensaje
        }

        if (other.gameObject.name == "BookLock" && photonView.IsMine && GameManager.lock1CanBeSeen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerLockMenu.SetActive(true);
        }

        if (other.gameObject.tag == "Door")
        {
            Debug.Log("tocando puerta");
            GameObject door = other.gameObject;
            gameManager.OpenDoor(door);
        }


        //mostrar el papel de bienvenida al jugador, solo el que lo ha triggereado
        if (other.gameObject.name == "Papel Bienvenida" && photonView.IsMine)
        {
            primeraPista.SetActive(true);
        }

        if (other.gameObject.name == "Primera Pista" && photonView.IsMine)
        {
            segundaPista.SetActive(true);
        }

        if (other.gameObject.name == "Tecera Pista(Clone)" && photonView.IsMine)
        {
            terceraPista.SetActive(true);
        }
        if (other.gameObject.name == "stone_row_1" && photonView.IsMine)
        {
            Debug.Log("entre en 1");
            object[] data = { true, (int)1 };
            PhotonNetwork.RaiseEvent((byte)Events.CAN_ROTATE_STONES, data, options, SendOptions.SendUnreliable);
        }
        if (other.gameObject.name == "stone_row_2" && photonView.IsMine)
        {
            object[] data = { true, (int)2 };
            PhotonNetwork.RaiseEvent((byte)Events.CAN_ROTATE_STONES, data, options, SendOptions.SendUnreliable);
        }
        if (other.gameObject.name == "stone_row_3" && photonView.IsMine)
        {
            object[] data = { true, (int)3 };
            PhotonNetwork.RaiseEvent((byte)Events.CAN_ROTATE_STONES, data, options, SendOptions.SendUnreliable);
        }

        //--------------------------------------------
        if (other.gameObject.name == "PapelPistaLetras" && photonView.IsMine)
        {
            PistaLetras.SetActive(true);
        }

        if (sword2.name == "sword_a (1)")
        {
            sword.GetComponent<Rigidbody>().useGravity = true;
            // sword.SetActive(true);
        }
        //----------------------------------------------


        ///SALA 3
        if (other.gameObject.name == "Papel prueba" && photonView.IsMine)
        {
            gameManager.potionCanvas.SetActive(true);
            gameManager.OnPause();
        }

        if (other.gameObject.name == "ArmarioDesordenado" && photonView.IsMine && !drawerSolved)
        {
            Debug.Log("tocas un objecto que interactúa");
            gameManager.drawerCanvas.SetActive(true);
            Cursor.visible = true;
            gameManager.OnPause();

        }

        if (other.gameObject.name == "Elementos" && photonView.IsMine && !gameManager.elementsPuzzleSolved)
        {
            gameManager.puzzleElementosCanvas.SetActive(true);
            Cursor.visible = true;
            gameManager.OnPause();
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
        if (other.gameObject.name == "stone_row_1" && photonView.IsMine)
        {
            object[] data = { false, (int)1 };
            PhotonNetwork.RaiseEvent((byte)Events.CAN_ROTATE_STONES, data, options, SendOptions.SendUnreliable);
        }
        if (other.gameObject.name == "stone_row_2" && photonView.IsMine)
        {
            object[] data = { false, (int)2 };
            PhotonNetwork.RaiseEvent((byte)Events.CAN_ROTATE_STONES, data, options, SendOptions.SendUnreliable);
        }
        if (other.gameObject.name == "stone_row_3" && photonView.IsMine)
        {
            object[] data = { false, (int)3 };
            PhotonNetwork.RaiseEvent((byte)Events.CAN_ROTATE_STONES, data, options, SendOptions.SendUnreliable);
        }
        if (other.gameObject.name == "PapelPistaLetras" && photonView.IsMine)
        {
            PistaLetras.SetActive(false);
        }
    }

    /*
     * Deshabilita el canvas que le pases tras 5 segundos
     * 
     * @param gameObject -> canvas
     */
    IEnumerator WaitFor2Sec(GameObject gameObject)
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);


    }


}


