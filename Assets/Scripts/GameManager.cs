using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{

    public GameManager gameManager;
    public PhotonView photonView;
    public TextMeshProUGUI lock1;
    public TextMeshProUGUI lock2;
    public TextMeshProUGUI lock3;
    public TextMeshProUGUI lock4;

    public GameObject inventory;

    private InventoryManager inventoryManager;
    private bool isShowing = false;

    private void Update()
    {
        if (!PhotonNetwork.InRoom || PhotonNetwork.IsMasterClient && photonView.IsMine) { 

        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            isShowing = !isShowing;
            Cursor.visible = isShowing;
            InventoryManager.Instance.ListItems();
            inventory.SetActive(isShowing);
            if (isShowing)
            {
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }else
            {
                Time.timeScale = 1;
            }
        }
    }

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

    public void Resume() {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }


}
