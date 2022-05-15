using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using ExitGames.Client.Photon;
using System.Linq;
using MadnessEscape2.Assets.Scripts;

public class GameManager : MonoBehaviourPun
{

    //basics
    public static GameManager instance;
    public PhotonView photonView;
    BookManager bookManager;
    PlayerManager playerManager;

    //public SetTargetFrameRate targetFrameRate;

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
    public GameObject terceraPista;


    private GameObject lever1;
    private GameObject lever2;
    private GameObject lever3;
    private GameObject lever4;

    private GameObject lever5;

    public GameObject potionCanvas;
    public GameObject drawerCanvas;
    public GameObject puzzleElementosCanvas;



    //Inventory Manager
    public InventoryManager inventoryManager;


    //bool
    private bool isShowingInventory = false;
    //variable para decirle al juego si debe hacer check de cuantos cubos tenemos en inventario
    private bool checkBuckets = true;
    private bool checkBooks = true;

    private bool checkKey1 = true;
    private bool checkMorningStar = true;
    private bool checkRock = true;

    private bool checkLever = true;

    public static bool door1CanBeOpened { get; set; } = false;
    public static bool door2CanBeOpened { get; set; } = false;
    public static bool lock1CanBeSeen { get; set; } = false;
    public static bool playerHasMorningStar { get; set; } = false;

    private bool lever1up;
    private bool lever2up;
    private bool lever3up;
    private bool lever4up;
    public bool lever5up;
    private bool moveRock1 = false;
    private bool moveRock2 = false;
    private bool moveRock3 = false;
    private bool checkPotions = true;
    private bool greenPotionCorrectPosition = false;

    private bool redPotionCorrectPosition = false;
    private bool bluePotionCorrectPosition = false;

    //Variables
    private int[] bookLockValue = { 5, 4, 2, 7 }; //array para probar el candado


    //variables sala3
    public Text valueml3, valueml5, valueml8;
    public static int ml3 = 0;
    public static int ml5 = 0;
    public static int ml8 = 8;
    public bool potionReceived = false;
    public bool elementsPuzzleSolved = false;
    public bool lightPuzzleSolved = false;
    public bool booksPuzzleSolved = false;

    private void Awake()
    {
        
    }

    private void Start()
    {
        GameObject.Find("stone_row_1").transform.Rotate(0f, 0f, Random.Range(0, 360));
        GameObject.Find("stone_row_2").transform.Rotate(0f, 0f, Random.Range(0, 360));
        GameObject.Find("stone_row_3").transform.Rotate(0f, 0f, Random.Range(0, 360));
        lever1 = GameObject.Find("Lever1").transform.GetChild(1).gameObject;
        lever2 = GameObject.Find("Lever2").transform.GetChild(1).gameObject;
        lever3 = GameObject.Find("Lever3").transform.GetChild(1).gameObject;
        lever4 = GameObject.Find("Lever4").transform.GetChild(1).gameObject;

        //--------------------------
        lever5 = GameObject.Find("Lever5").transform.GetChild(1).gameObject;
        //--------------------------

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
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        if (checkPotions)
        {
            if (!greenPotionCorrectPosition && GameObject.Find("Potion_green").gameObject.transform.position.z > 24.21f && GameObject.Find("Potion_green").gameObject.transform.position.z < 25.762f && GameObject.Find("Potion_green").gameObject.transform.position.x < 1.5f && GameObject.Find("Potion_green").gameObject.transform.position.x > 0.6f && GameObject.Find("Potion_green").gameObject.transform.position.y < 1f)
            {
                greenPotionCorrectPosition = true;
            }
            if (!redPotionCorrectPosition && GameObject.Find("Potion_red").gameObject.transform.position.z > 20.479f && GameObject.Find("Potion_red").gameObject.transform.position.z < 21.604f && GameObject.Find("Potion_red").gameObject.transform.position.x < 13.106F && GameObject.Find("Potion_red").gameObject.transform.position.x > 11.9f && GameObject.Find("Potion_red").gameObject.transform.position.y < 1f)
            {
                redPotionCorrectPosition = true;
            }
            if (!bluePotionCorrectPosition && GameObject.Find("Potion_blue").gameObject.transform.position.z > 27.357f && GameObject.Find("Potion_blue").gameObject.transform.position.z > 27.357f && GameObject.Find("Potion_blue").gameObject.transform.position.z < 28.446f && GameObject.Find("Potion_blue").gameObject.transform.position.y < 1f && GameObject.Find("Potion_blue").gameObject.transform.position.x > 11.7f && GameObject.Find("Potion_blue").gameObject.transform.position.x < 13.2f)
            {
                bluePotionCorrectPosition = true;
            }
            if(greenPotionCorrectPosition && redPotionCorrectPosition && bluePotionCorrectPosition)
            {
                RaiseEventOptions options = new RaiseEventOptions()
                {
                    CachingOption = EventCaching.DoNotCache,
                    Receivers = ReceiverGroup.All
                };
                PhotonNetwork.RaiseEvent((byte)Events.OPEN_CLOSET2_ROOM_1_EVENT, null, options, SendOptions.SendReliable);
                checkPotions = false;
            }
        }

        //checks para las palancas
        if (lever1 != null)
        {
            lever1up = lever1.transform.localRotation.eulerAngles.x > 150;
            lever2up = lever2.transform.localRotation.eulerAngles.x > 150;
            lever3up = lever3.transform.localRotation.eulerAngles.x > 150;
            lever4up = lever4.transform.localRotation.eulerAngles.x > 150;
            //---------
            lever5up = lever5.transform.localRotation.eulerAngles.x > 150;
            //-----------
        }
        //se comprobara siempre que se tenga que comprobar el estado de las palancas
        if (checkLever)
        {
            if (lever1up && !lever2up && !lever3up && lever4up)
            {
                //se abre la puerta del closet y se pone checkLever a false para que no se vuelva a comprobar
                OpenClosetDoor();
                checkLever = false;
            }
        }
//---------------------
        if (checkLever)
        {
            if (!lever5up)
            {
                
                checkLever = false;
            }
        }
//-------------------------       

        if(checkRock) checkRocks();

        //Si est� el men� de candado abierto revisa si se cumple el puzzle
        if (playerLockCanvas.active)
        {
            checkBookLockResult();
        }

        //si la variable de check cubos en el inventario es true llamaremos a la funcion
        if (checkBuckets) checkBucketsInInventory();
        if (checkBooks) checkBooksInInventory();


        //Check para saber si el jugador tiene una llave en su inventario
        if (checkKey1 && inventoryManager.Items.Where(x => x.itemName.Equals("Key1")).ToList<Item>().Count() == 1)
        {
            checkKey1 = false;
            lock1CanBeSeen = true;
        }

        //Check para saber si un jugador tiene el martillo en su inventario
        if (checkMorningStar && inventoryManager.Items.Where(x => x.itemName.Equals("MorningStar")).ToList<Item>().Count() == 1)
        {
            checkMorningStar = false;
            playerHasMorningStar = true;
        }

        


        //Si el canvas de pociones esta activo revisa que se solucione el problema
        if (potionCanvas.active)
        {
            PuzzleWater();
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


    /*
     * 
     * Escribe un mensaje en pantalla que desaparece a los 2 segundos
     * @param
     * message -> el mensaje que aparecerá en pantalla
     */
    void printMessageOnScreen(string message)
    {
        playerCanvas.SetActive(true);
        playerCanvas.GetComponentInChildren<TextMeshPro>().text = message;
        StartCoroutine(WaitFor2Sec(playerCanvas));
    }

    //reinicia los comandos rotaci�n y movimiento del jugador
    public void OnResume()
    {
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
            OpenSecondRoomChest();
        }
    }

    private void checkRocks()
    {
        if(((GameObject.Find("stone_row_1").transform.rotation.eulerAngles.z >= 85f && GameObject.Find("stone_row_1").transform.rotation.eulerAngles.z <= 95f) || (GameObject.Find("stone_row_1").transform.rotation.z >= -5f && GameObject.Find("stone_row_1").transform.rotation.z <= 5f)) &&
           (GameObject.Find("stone_row_2").transform.rotation.eulerAngles.z >= 85f && GameObject.Find("stone_row_2").transform.rotation.eulerAngles.z <= 95f) || (GameObject.Find("stone_row_2").transform.rotation.eulerAngles.z >= -5f && GameObject.Find("stone_row_2").transform.rotation.eulerAngles.z <= 5f) &&
           (GameObject.Find("stone_row_3").transform.rotation.eulerAngles.z >= 85f && GameObject.Find("stone_row_3").transform.rotation.eulerAngles.z <= 95f) || (GameObject.Find("stone_row_3").transform.rotation.eulerAngles.z >= -5f && GameObject.Find("stone_row_3").transform.rotation.eulerAngles.z <= 5f))
        {
            RaiseEventOptions options = new RaiseEventOptions()
            {
                CachingOption = EventCaching.DoNotCache,
                Receivers = ReceiverGroup.All
            };
            PhotonNetwork.RaiseEvent((byte)Events.OPEN_CHEST2_ROOM_2, null, options, SendOptions.SendReliable);
        }
    }


    /*
     * Desactiva el gameObject que se le pasa
     * @params gameObject
     *  Recordad que es una Corutina, lo llamamos con StartCoroutine(WaitForSeconds(gameObject))
     */
    IEnumerator WaitFor2Sec(GameObject gameObject)
    {
        Debug.Log("deberia cerrarse");
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);

        ///Elimina texto si tiene
        if (gameObject.GetComponentInChildren<TextMeshProUGUI>() != null)
        {
            TextMeshProUGUI thisText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            thisText.text = "";
        }

    }

    public void OpenDoor(GameObject door)
    {

    }

    public void closeCanvas(GameObject gameObject)
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }



    //Funcion para checkear el numero de cubos en el inventario
    private void checkBucketsInInventory()
    {
        int bucketInInventory = 0;
        //Recorremos el inventario
        inventoryManager.Items.ForEach(item =>
        {
            if (item.itemName.Equals("Bucket")) bucketInInventory++;
        });

        //si tenemos 3 cubos, ponemos el checkBuckets a true para que no se vuelva a ejecutar la funcion
        //y ahorrar capacidad de proceso, y también ponemos a true la variable estatica door1CanBeOpened
        if (bucketInInventory == 2)
        {
            GameManager.door1CanBeOpened = true;
            checkBuckets = false;
        }
    }

    private void checkBooksInInventory()
    {
        int bookInInventory = 0;
        //Recorremos el inventario
        inventoryManager.Items.ForEach(item =>
        {
            if (item.itemName.Equals("Book")) bookInInventory++;
        });

        //si tenemos 3 cubos, ponemos el checkBuckets a true para que no se vuelva a ejecutar la funcion
        //y ahorrar capacidad de proceso, y también ponemos a true la variable estatica door1CanBeOpened
        if (bookInInventory == 2)
        {
            GameManager.door2CanBeOpened = true;
            checkBooks = false;
        }
    }

    private void OpenSecondRoomChest()
    {
        RaiseEventOptions options = new RaiseEventOptions()
        {
            CachingOption = EventCaching.DoNotCache,
            Receivers = ReceiverGroup.All
        };
        PhotonNetwork.RaiseEvent((byte)Events.OPEN_CHEST_ROOM_2, null, options, SendOptions.SendReliable);
    }

    //Enviar evento por red a todos los jugadores de la sala, para abrir la puerta del armario
    private void OpenClosetDoor()
    {
        RaiseEventOptions options = new RaiseEventOptions()
        {
            CachingOption = EventCaching.DoNotCache,
            Receivers = ReceiverGroup.All
        };
        PhotonNetwork.RaiseEvent((byte)Events.OPEN_CLOSET_ROOM_1_EVENT, null, options, SendOptions.SendReliable);
    }

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }

    //Quitar listener al deshabilitar el gameObject
    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived;
    }

    //Este es el metodo que recibira el paquete, si el codigo es igual a 1, llamaremos a la funcion OpenDoor
    private void NetworkingClient_EventReceived(EventData obj)
    {
        if (obj.Code == (uint)Events.OPEN_CLOSET_ROOM_1_EVENT)
        {
            if (GameObject.Find("morningStar(Clone)") == null && photonView.IsMine && GameObject.Find("MorningStar Variant(Clone)") == null)
            {
                Instantiate(morningStarPrefab, new Vector3(7.9f, 0.89f, 0.693f), new Quaternion(-45f, 0f, 0f, 0f)).transform.Rotate(90f, 0f, 0f);
                morningStarPrefab.name = "morningStar";
                terceraPista.name = "Tecera Pista";
                Instantiate(terceraPista);
                GameObject.Find("Tecera Pista(Clone)").transform.position = new Vector3(0.507f, 1.939f, 28);
            }
        }
        if (obj.Code == (uint)Events.ROTATE_ITEM)
        {
            float data = (float)obj.CustomData;
            if (moveRock1)
            {
                GameObject.Find("stone_row_1").transform.Rotate(0, 0, data);
            }
            if (moveRock2)
            {
                GameObject.Find("stone_row_2").transform.Rotate(0f, 0f, data);
            }
            if (moveRock3)
            {
                GameObject.Find("stone_row_3").transform.Rotate(0f, 0f, data);
            }
        }
        if (obj.Code == (uint)Events.CAN_ROTATE_STONES)
        {
            object[] datas = (object[])obj.CustomData;
            switch ((int)datas[1])
            {
                case 1:
                    moveRock1 = (bool)datas[0];
                    break;
                case 2:
                    moveRock2 = (bool)datas[0];
                    break;
                case 3:
                    moveRock3 = (bool)datas[0];
                    break;
                default:
                    break;

            }
        }

        if(obj.Code == (uint)Events.OPEN_WALL){       
                    
            FindObjectOfType<ControllerAnimations>().openWall();
                
        }

        if(obj.Code == (uint)Events.ELEMENT_SOLVED){       
                    
           PlayerManager.potionUnlocked = true;
           Debug.Log(PlayerManager.potionUnlocked);                
        }
        
        if(obj.Code == (uint)Events.LIGHT_SOLVED){
            lightPuzzleSolved = true;
        }
        if(obj.Code == (uint)Events.OPEN_FINAL_DOOR){
            if (lightPuzzleSolved && potionReceived)
            {
                printMessageOnScreen("Rápido, ya he abierto la puerta!");
                openFinalDoor();
            }
            else if(!lightPuzzleSolved && potionReceived)
            {
                printMessageOnScreen("Necesito que activéis el mecanismo secreto de las luces!");
            }
            else if(lightPuzzleSolved && !potionReceived)
            {
                printMessageOnScreen("Necesito que activéis el mecanismo secreto de las luces!");
            }
        }
    }

    public void bookSolved(){
                booksPuzzleSolved = true;  
                Debug.Log(GameObject.Find("CanvasArmario").active);
                    if(GameObject.Find("CanvasArmario").active){
                         Debug.Log("deberia cerrarse");                    
                    Debug.Log(drawerCanvas);    
                        OnResume();
                    GameObject.Find("CanvasArmario").SetActive(false);  
                    }             
                 var buttons = GameObject.FindGameObjectsWithTag("botonLlamas");
                foreach (var item in buttons){
            item.transform.position = new Vector3(item.transform.position.x,item.transform.position.y+0.1f,item.transform.position.z);
        }             
                RaiseEventOptions options = new RaiseEventOptions()
                {
                    CachingOption = EventCaching.DoNotCache,
                    Receivers = ReceiverGroup.All
                };
                PhotonNetwork.RaiseEvent((byte)Events.OPEN_WALL, null, options, SendOptions.SendReliable);            
    }

     

    void PuzzleWater()
    {
        Debug.Log("puzzl activado");
        ml3 = int.Parse(valueml3.text);
        ml5 = int.Parse(valueml5.text);
        ml8 = int.Parse(valueml8.text);

        if (ml5 == 4 && ml8 == 4)
        {
            //puzzle conseguido
            Debug.Log("conseguido");
            potionReceived = true;
            OnResume();
            StartCoroutine(WaitFor2Sec(potionCanvas));
            RaiseEventOptions options = new RaiseEventOptions()
                {
                    CachingOption = EventCaching.DoNotCache,
                    Receivers = ReceiverGroup.All
                };
                PhotonNetwork.RaiseEvent((byte)Events.POTION_SOLVED, null, options, SendOptions.SendReliable);
                PhotonNetwork.RaiseEvent((byte)Events.OPEN_FINAL_DOOR, null, options, SendOptions.SendReliable);
        }
    }

    
    void openFinalDoor(){
        var doors = FindObjectsOfType<FinalDoorController>();
        Debug.Log(doors.Length);
        foreach (var item in doors)
        {
            item.openDoor();
        }
    }

}
