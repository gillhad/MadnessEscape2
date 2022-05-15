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
    PlayfabManager pfm;

    public Countdown cd;
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

    public GameObject canvasArmarioDesordenado;

    public GameObject PistaLetras;

    public GameObject PistaArmario;
    public GameObject PistaJarrones;

    public GameObject Sueño;
    public GameObject canvasPista32;
    public GameObject canvasTabla;
    public GameObject canvasArmarioElementos;
    public GameObject HUD;

    bool drawerSolved = false;

    static public bool potionUnlocked = false;




    RaiseEventOptions options = new RaiseEventOptions()
    {
        CachingOption = EventCaching.DoNotCache,
        Receivers = ReceiverGroup.All
    };


    private void Start()
    {
        HUD = GameObject.Find("HUD");
        if (gameManager == null)
        {
            gameManager = gameManager = FindObjectOfType<GameManager>();
        }

        if (PistaArmario == null)
        {
            PistaArmario = GameObject.FindGameObjectWithTag("PistaArmario22");
        }
        if (GameObject.Find("CanvasPistaSala3") != null)
        {
            canvasPista32.SetActive(true);
        }

    }
    void Update()
    {

        if (PhotonNetwork.InRoom && !photonView.IsMine)
        {
            playerCamera.gameObject.SetActive(false);
            return;
        }

        if(potionUnlocked){
            Debug.Log("deberia abrirse las pociones");
        }

    }

    //prueba para mover la c�mara cuando pase algo **pendiente de revisar**
    public void CameraShake()
    {
        playerCamera.transform.localRotation = Quaternion.Euler(Random.Range(-2f, 2f), 0, 0);

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BookLock" && photonView.IsMine && GameManager.lock1CanBeSeen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayerMovement.speed = 0f;
            Time.timeScale = 0;
            playerLockMenu.SetActive(true);
        }

        if (other.gameObject.tag == "Door")
        {
            Debug.Log("tocando puerta");
            GameObject door = other.gameObject;
            gameManager.OpenDoor(door);
        }

        if (other.gameObject.name == "Valve_main")
        {
            HUD.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
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

        if (other.gameObject.name == "wood_logs (2)" && photonView.IsMine)
        {
            PistaArmario.SetActive(true);
        }

        if (other.gameObject.name == "Table_Wooden_02 (1)" && photonView.IsMine)
        {
            Sueño.SetActive(true);
        }
        if (other.gameObject.name == "Paperrr" && photonView.IsMine)
        {
            PistaJarrones.SetActive(true);
        }

        if (other.gameObject.name == "Treasure_Chest_Base_01" && photonView.IsMine)
        {
            Candado.onTrigger = true;
            
        }
        if (other.gameObject.name == "Paper_04" && photonView.IsMine)
        {
            Keypad.onTrigger = true;
            
        }


        //----------------------------------------------


        ///SALA 3
        if (other.gameObject.name == "Pista32" && photonView.IsMine)
        {
            canvasPista32.SetActive(true);
        }

        if (potionUnlocked)
        {
            Debug.Log("va, abre las pociones");
            if (other.gameObject.name == "PapelPociones" && photonView.IsMine && potionUnlocked)
            {
                Debug.Log("pantalla de pociones");
                gameManager.OnPause();
                gameManager.potionCanvas.SetActive(true);
                Debug.Log("se ha abirto corrctamnte l canvas");

            }
        }

        if (other.gameObject.name == "ArmarioDesordenado" && photonView.IsMine && !drawerSolved)
        {
            Debug.Log("tocas un objecto que interactúa");
            gameManager.OnPause();
            gameManager.drawerCanvas.SetActive(true);
            Cursor.visible = true;


        }

        if (other.gameObject.name == "ArmarioElementos" && photonView.IsMine && !gameManager.elementsPuzzleSolved)
        {
            gameManager.puzzleElementosCanvas.SetActive(true);
            Cursor.visible = true;
            gameManager.OnPause();
        }

        if (other.gameObject.name == "TablaPer" && photonView.IsMine)
        {
            canvasTabla.SetActive(true);
        }

        if (other.gameObject.name == "The End")
        {
            //todo final juego
             pfm = GameObject.FindGameObjectWithTag("escena").GetComponent<PlayfabManager>();
             pfm.SendLeaderboard(cd.minutes, cd.seconds);
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
        if (other.gameObject.name == "Valve_main")
        {
            HUD.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
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
        if (other.gameObject.name == "wood_logs (2)" && photonView.IsMine)
        {
            PistaArmario.SetActive(false);
        }
        if (other.gameObject.name == "Table_Wooden_02 (1)" && photonView.IsMine)
        {
            Sueño.SetActive(false);
        }
        if (other.gameObject.name == "Treasure_Chest_Base_01" && photonView.IsMine)
        {
            Candado.onTrigger = false;
        }
        if (other.gameObject.name == "Pista32" && photonView.IsMine)
        {

            canvasPista32.SetActive(false);
        }
        if (other.gameObject.name == "TablaPer" && photonView.IsMine)
        {
            canvasTabla.SetActive(false);
        }
        if (other.gameObject.name == "Paperrr" && photonView.IsMine)
        {
            PistaJarrones.SetActive(false);
        }

        if (other.gameObject.name == "Treasure_Chest_Base_01" && photonView.IsMine)
        {
            Candado.onTrigger = false;
            Candado.keypadScreen = false;
            Candado.input = "";
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (other.gameObject.name == "Paper_04" && photonView.IsMine)
        {
            Keypad.onTrigger = false;
            Keypad.keypadScreen = false;
            Keypad.input = "";
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (other.gameObject.name == "The End")
        {
            ///mostrar canvas d final y gaurdar datos partida
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



