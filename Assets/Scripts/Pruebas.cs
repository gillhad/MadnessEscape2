using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebas : MonoBehaviour
{


    //public void OnClickLockButton(TextMeshProUGUI lockText)
    //{
    //    string value = lockText.text;
    //    Debug.Log(value);
    //    int lockValue = int.Parse(value);
    //    if (lockValue < 9)
    //    {
    //        lockValue += 1;
    //    }
    //    else
    //    {
    //        lockValue = 0;

    //    }

    //    lockText.text = lockValue.ToString();
    //}

    //public void Resume()
    //{
    //    Cursor.lockState = CursorLockMode.Locked;
    //    Time.timeScale = 1;
    //}


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "ArmarioInteractua")
    //    {
    //        Debug.Log("has tocado el objeto");
    //        interactableText.gameObject.SetActive(true);
    //        interactableText.text = "PALOMITAS";
    //        Debug.Log("aquí debería estar activo");

    //        StartCoroutine(WaitFor2Sec(playerCanvas));
    //    }
    //    else if (other.gameObject.name == "BookLock")
    //    {
    //        playerLockMenu.SetActive(true);
    //        Cursor.lockState = CursorLockMode.None;
    //        Time.timeScale = 0;
    //    }




    //}

    ///*
    // * Deshabilita el canvas que le pases tras 5 segundos
    // * 
    // * @param gameObject -> canvas
    // */
    //IEnumerator WaitFor2Sec(GameObject gameObject)
    //{
    //    yield return new WaitForSeconds(5);
    //    gameObject.SetActive(false);


    //}




    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;


{

    public GameManager gameManager;
    public PhotonView photonView;
    public TextMeshProUGUI lock1;
    public TextMeshProUGUI lock2;
    public TextMeshProUGUI lock3;
    public TextMeshProUGUI lock4;
    public TextMeshProUGUI interactableText;
    public GameObject playerCanvas;
    public GameObject playerLockCanvas;

    private int[] bookLockValue = { 1, 2, 3, 4 };

    public GameObject inventory;

    private InventoryManager inventoryManager;
    private bool isShowingInvetory = false;

    private void Update()
    {
        if (!PhotonNetwork.InRoom || PhotonNetwork.IsMasterClient && photonView.IsMine)
        {

        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            isShowingInvetory = !isShowingInvetory;
            Cursor.visible = isShowingInvetory;
            InventoryManager.Instance.ListItems();
            inventory.SetActive(isShowingInvetory);
            if (isShowingInvetory)
            {
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("incentario");
            }
        }

        if (playerLockCanvas.active)
        {
            checkBookLockResult();
        }




    }

    public void OnClickLockButton(TextMeshProUGUI lockText)
    {
        string value = lockText.text;
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

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
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
            WaitFor2Sec(playerCanvas);
        }
    }


    IEnumerator WaitFor2Sec(GameObject gameObject)
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
        TextMeshProUGUI thisText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        thisText.text = "";



    }


}








}
