using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public GameObject endGameUi;
    [SerializeField] private TMP_Text timerText;

    [SerializeField, Tooltip("Tiempo en segundos")] public float timerTime;
    public int minutes, seconds, cents;

    public void Update(){

        timerTime -= Time.deltaTime;
        if (timerTime < 0) timerTime = 0;
        
        minutes = (int)(timerTime /60f);
        seconds = (int)(timerTime - minutes * 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        
        if (timerTime == 0)
        {
            
            Cursor.lockState = CursorLockMode.None;
            endGameUi.SetActive(true);
            Time.timeScale = 0f;
            Destroy(this);
            Debug.Log("Time Out");
        }
    }
}
