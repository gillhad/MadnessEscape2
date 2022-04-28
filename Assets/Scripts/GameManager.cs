using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using ExitGames.Client.Photon;
using System.Linq;


public class GameManager : MonoBehaviourPun
{
    private const byte OPEN_CLOSET_ROOM_1_EVENT = 3;

    //basics
    public static GameManager instance;
    public PhotonView photonView;

    //UI
    public TextMeshProUGUI lock1;
    public TextMeshProUGUI lock2;
    public TextMeshProUGUI lock3;
    public TextMeshProUGUI lock4;
    public TextMeshProUGUI interactableText;

    //GameObjects
    public GameObject playerCanvas;
    public GameObject playerLockCanvas;
    public GameObject inventory;
    public GameObject morningStarPrefab;

    private GameObject lever1;
    private GameObject lever2;
    private GameObject lever3;
    private GameObject lever4;

    //Inventory Manager
    public InventoryManager inventoryManager;

    
    //bool
    private bool isShowingInventory = false;
    //variable para decirle al juego si debe hacer check de cuantos cubos tenemos en inventario
    private bool checkBuckets = true;

    private bool checkKey1 = true;
    private bool checkMorningStar = true;

    private bool checkLever = true;

    public static bool door1CanBeOpened {get; set;} = false;
    public static bool door2CanBeOpened {get; set;} = false;
    public static bool lock1CanBeSeen {get; set;} = false;
    public static bool playerHasMorningStar {get; set;} = false;

    private bool lever1up;
    private bool lever2up;
    private bool lever3up;
    private bool lever4up;

    //Variables
    private int[] bookLockValue = { 1, 2, 3, 4 }; //array para probar el candado
    
    private void Start()
    {
        lever1 = GameObject.Find("Lever1").transform.GetChild(1).gameObject;
        lever2 = GameObject.Find("Lever2").transform.GetChild(1).gameObject;
        lever3 = GameObject.Find("Lever3").transform.GetChild(1).gameObject;
        lever4 = GameObject.Find("Lever4").transform.GetChild(1).gameObject;

    }
    private void Update()
    {

        //Abre el men� al pulsar "I"
        if (Input.GetKeyDown(KeyCode.I))
        {
            isShowingInventory = !isShowingInventory;
            Cursor.visible = isShowingInventory;
            InventoryManager.Instance.ListItems();
            inventory.SetActive(isShowingInventory);
            if (isShowingInventory)
            {
                OnPause();
            }else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        //checks para las palancas
        lever1up = lever1.transform.localRotation.eulerAngles.x > 150;
        lever2up = lever2.transform.localRotation.eulerAngles.x > 150;
        lever3up = lever3.transform.localRotation.eulerAngles.x > 150;
        lever4up = lever4.transform.localRotation.eulerAngles.x > 150;
        //se comprobara siempre que se tenga que comprobar el estado de las palancas
        if(checkLever){
            if(lever1up && !lever2up && !lever3up && lever4up)
                {
                    //se abre la puerta del closet y se pone checkLever a false para que no se vuelva a comprobar
                    OpenClosetDoor();
                    checkLever = false;
                }
        }

        //Si est� el men� de candado abierto revisa si se cumple el puzzle
        if (playerLockCanvas.active)
        {
            checkBookLockResult();
        }

        //si la variable de check cubos en el inventario es true llamaremos a la funcion
        if(checkBuckets) checkBucketsInInventory();


        //Check para saber si el jugador tiene una llave en su inventario
        if(checkKey1 && inventoryManager.Items.Where(x => x.itemName.Equals("Key1")).ToList<Item>().Count() == 1)
        {
            checkKey1 = false;
            lock1CanBeSeen = true;
        }

        //Check para saber si un jugador tiene el martillo en su inventario
        if(checkMorningStar && inventoryManager.Items.Where(x => x.itemName.Equals("MorningStar")).ToList<Item>().Count() == 1)
        {
            Debug.Log("tengo el martillo");
            checkMorningStar = false;
            playerHasMorningStar = true;
        }

    }

    /*
     * Cambia los n�meros del candado 0-9 
     * @params le pasa el par�metro de texto del bot�n para que lo lea y modifique
     *  
     */
    
    public void OnClickLockButton(TextMeshProUGUI lockText)
    {
        string value = lockText.text;
        Debug.Log(value);
        int lockValue = int.Parse(value);
        if (lockValue < 9)
        {
            lockValue += 1;
        }
        else
        {
            lockValue = 0;

        }

        lockText.text = lockValue.ToString();
    }


    //reinicia los comandos rotaci�n y movimiento del jugador
    public void OnResume() {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }


    //Pausa los comandos de rotaci�n y movimiento del jugador
    public void OnPause()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public void checkBookLockResult()
    {
        int book1 = int.Parse(lock1.text);
        int book2 = int.Parse(lock2.text);
        int book3 = int.Parse(lock3.text);
        int book4 = int.Parse(lock4.text);


        if (book1 == bookLockValue[0] && book2 == bookLockValue[1] && book3 == bookLockValue[2] && book4 == bookLockValue[3])
        {
            playerLockCanvas.SetActive(false);
            playerCanvas.SetActive(true);
            interactableText.text = "lo has conseguido!";
            StartCoroutine(WaitFor2Sec(playerCanvas));
        }
    }

    

    /*
     * Desactiva el gameObject que se le pasa
     * @params gameObject
     *  Recordad que es una Corutina, lo llamamos con StartCoroutine(WaitForSeconds(gameObject))
     */
    IEnumerator WaitFor2Sec(GameObject gameObject)
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        TextMeshProUGUI thisText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        thisText.text = "";

    }

    public void OpenDoor(GameObject door) {
        
        }

    public void PrintText() {

        Debug.Log("texto");
    }

    //Funcion para checkear el numero de cubos en el inventario
    private void checkBucketsInInventory(){
        int bucketInInventory = 0;
        //Recorremos el inventario
        inventoryManager.Items.ForEach(item => {
            if(item.itemName.Equals("Bucket")) bucketInInventory++;
        });

        //si tenemos 3 cubos, ponemos el checkBuckets a true para que no se vuelva a ejecutar la funcion
        //y ahorrar capacidad de proceso, y también ponemos a true la variable estatica door1CanBeOpened
        if(bucketInInventory == 3){
            checkBuckets = false;
            door1CanBeOpened = true;
        }
    }

    //Enviar evento por red a todos los jugadores de la sala, para abrir la puerta del armario
    private void OpenClosetDoor()
    {
        RaiseEventOptions options = new RaiseEventOptions()
        {
            CachingOption = EventCaching.DoNotCache,
            Receivers = ReceiverGroup.All
        };
        PhotonNetwork.RaiseEvent(OPEN_CLOSET_ROOM_1_EVENT, null, options, SendOptions.SendReliable);
    }

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }

    //Quitar listener al deshabilitar el gameObject
    private void OnDisable(){
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived;
    }

    //Este es el metodo que recibira el paquete, si el codigo es igual a 1, llamaremos a la funcion OpenDoor
    private void NetworkingClient_EventReceived(EventData obj){
        if(obj.Code == OPEN_CLOSET_ROOM_1_EVENT)
        {
            if(GameObject.Find("morningStar(Clone)") == null && photonView.IsMine)
            {
                Instantiate(morningStarPrefab, new Vector3(7.9f, 0.89f, 0.693f), new Quaternion(-45f, 0f, 0f, 0f)).transform.Rotate(90f, 0f, 0f);
                morningStarPrefab.name = "morningStar";
                Debug.Log("hola");
            }
        }
    }
}
