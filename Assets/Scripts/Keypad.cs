using UnityEngine;
using System.Collections;

public class Keypad : MonoBehaviour
{

    public string curPassword = "36667777";
    public static string input;
    public static bool onTrigger;
    public static bool closetDown;
    public static bool keypadScreen;
    public Transform closetHinge;
     GameObject audioObject;
     AudioSource audio;

     void Awake(){
     }

    void Start(){
     audio = GetComponent<AudioSource>();   
    }

    void OnTriggerEnter(Collider other)
    {
        //  onTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        //  onTrigger = false;
        //  keypadScreen = false;
        //  input = "";
        //  Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (input == curPassword)
        {
            Debug.Log("se cae");
            Time.timeScale = 1f;
            closetDown = true;
            keypadScreen = false;
            Cursor.lockState = CursorLockMode.Locked;   
            Debug.Log(audioObject);   
            Debug.Log(audio);         
             audio.Play();            

            
        }

        if (closetDown)
        {
            var newRot = Quaternion.RotateTowards(closetHinge.rotation, Quaternion.Euler(-90f, 0.0f, 0.0f), Time.deltaTime * 250);
            closetHinge.rotation = newRot;
        }
    }

    void OnGUI()
    {
        if (!closetDown)
        {
            if (onTrigger)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "Press 'E' to open keypad");

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
                if (GUI.Button(new Rect(215, 350, 100, 100), "X"))
                {
                    keypadScreen = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    Time.timeScale = 1f;

                }
            }
        }
    }
}
