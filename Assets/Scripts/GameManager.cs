using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{

    //basics
    public GameManager gameManager;
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

    private InventoryManager inventoryManager;

    //bool
    private bool isShowingInventory = false;

    //Variables
    private int[] bookLockValue = { 1, 2, 3, 4 }; //array para probar el candado

    private void Start()
    {
        
    }
    private void Update()
    {
        if (!PhotonNetwork.InRoom || PhotonNetwork.IsMasterClient && photonView.IsMine) { 

        }

        //Abre el menú al pulsar "I"
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
            }
        }

        //Si está el menú de candado abierto revisa si se cumple el puzzle
        if (playerLockCanvas.active)
        {
            checkBookLockResult();
        }




    }

    /*
     * Cambia los números del candado 0-9 
     * @params le pasa el parámetro de texto del botón para que lo lea y modifique
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


    //reinicia los comandos rotación y movimiento del jugador
    public void OnResume() {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }


    //Pausa los comandos de rotación y movimiento del jugador
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

}
