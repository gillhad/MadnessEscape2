using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleElementos : MonoBehaviour
{
    GameManager gameManager;

    public InputField luci1;
    public InputField luci2;
    public InputField luci3;
    public InputField luci4;
    public InputField luci5;

    public InputField vati1;
    public InputField vati2;
    public InputField vati3;
    public InputField vati4;
    public InputField vati5;
    public InputField vati6;

    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = gameManager = FindObjectOfType<GameManager>();
        }
    }

    void Update()
    {

        if (luci1.text == "70" && luci2.text == "" && luci3.text == "" && luci4.text == "" && luci5.text == "") { 
        
        }

    }
}
