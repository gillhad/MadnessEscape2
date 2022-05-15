using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candado : MonoBehaviour
{
    public string curPassword = "231";
    public static string input;
    public static bool onTrigger = false;
    public static bool chestOpened;
    public static bool keypadScreen;
    public Transform chestHinge;

    public GameObject key;


    void OnTriggerEnter(Collider other)
    {
       // onTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
       // onTrigger = false;
       // keypadScreen = false;
       // input = "";
       // Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (input == curPassword)
        {
            chestOpened = true;
        }

        if (chestOpened)
        {
            Time.timeScale = 1f;
            var newRot = Quaternion.RotateTowards(chestHinge.rotation, Quaternion.Euler(-180.0f, 0.0f, 0.0f), Time.deltaTime * 250);
            chestHinge.rotation = newRot;
            key.SetActive(true);
            key.GetComponent<Rigidbody>().useGravity = true;

        }
    }

    void OnGUI()
    {
        if (!chestOpened)
        {
            if (onTrigger)
            {
                GUI.Box(new Rect(Screen.width / 2 - 320 / 2, Screen.height / 2f, 200, 25), "Press 'E' to open");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Cursor.lockState = CursorLockMode.None;
                    Time.timeScale = 0f;
                    keypadScreen = true;
                    onTrigger = false;
                }
            }

            if (keypadScreen)
            {
                GUI.Box(new Rect(0, 0, 320, 455), "");
                GUI.Box(new Rect(5, 5, 310, 25), input);

                if (GUI.Button(new Rect(5, 35, 100, 100), "1"))
                {
                    input = input + "1";
                }

                if (GUI.Button(new Rect(110, 35, 100, 100), "2"))
                {
                    input = input + "2";
                }

                if (GUI.Button(new Rect(215, 35, 100, 100), "3"))
                {
                    input = input + "3";
                }

                if (GUI.Button(new Rect(5, 140, 100, 100), "4"))
                {
                    input = input + "4";
                }

                if (GUI.Button(new Rect(110, 140, 100, 100), "5"))
                {
                    input = input + "5";
                }

                if (GUI.Button(new Rect(215, 140, 100, 100), "6"))
                {
                    input = input + "6";
                }

                if (GUI.Button(new Rect(5, 245, 100, 100), "7"))
                {
                    input = input + "7";
                }

                if (GUI.Button(new Rect(110, 245, 100, 100), "8"))
                {
                    input = input + "8";
                }

                if (GUI.Button(new Rect(215, 245, 100, 100), "9"))
                {
                    input = input + "9";
                }

                if (GUI.Button(new Rect(110, 350, 100, 100), "0"))
                {
                    input = input + "0";
                }
            }
        }
    }
}
