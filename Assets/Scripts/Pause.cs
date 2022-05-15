using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;

    PlayfabManager pfm;

    public Countdown cd;

    



    void Update()
    {

         if (Input.GetKeyDown(KeyCode.Escape))
         {
             pfm = GameObject.FindGameObjectWithTag("escena").GetComponent<PlayfabManager>();
             pfm.SendLeaderboard(cd.minutes, cd.seconds);

             if (GameIsPaused)
             {
                 Resume();
             }
             else
             {
                 Paused();
             }
         }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Paused()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Quit()
    {
        // StartCoroutine(LeaveAndLoad());
        Application.Quit();
    }

    /* IEnumerator LeaveAndLoad(){
         PhotonNetwork.LeaveRoom();
         while(PhotonNetwork.InRoom)
             yield return null;
         if (!PhotonNetwork.InRoom)
         {
             SceneManager.LoadScene(0);
         }

     }*/

}
