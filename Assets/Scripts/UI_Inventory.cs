using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    public GameObject inventory;

    private InventoryManager inventoryManager;
    private bool isShowing = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            isShowing = !isShowing;
            Cursor.visible = isShowing;
            InventoryManager.Instance.ListItems();
            inventory.SetActive(isShowing);
            if(isShowing)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }

    }
}
