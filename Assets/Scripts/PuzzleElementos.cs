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

        if (luci1.text == "71" && luci2.text == "6" && luci3.text == "53" && luci4.text == "9" && luci5.text == "68"
            && vati1.text == "23" && vati2.text == "85" && vati3.text == "53" && vati4.text == "20" && vati5.text == "7" && vati6.text == "8") {
            Debug.Log("puzzle solved");
            gameManager.elementsPuzzleSolved = true;
        }

    }
}
