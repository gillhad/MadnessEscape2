using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager sharedInstance;
    public bool player1 = false;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
            DontDestroyOnLoad(sharedInstance);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Vector3 spawnPosition1 = new Vector3(4f, 2f, 4f);
        Vector3 spawnPosition2 = new Vector3(10f, 2f, 30f);

        if (PhotonNetwork.InRoom)
        {
            if (PhotonNetwork.PlayerList.Length==1)
            {
                PhotonNetwork.Instantiate("FPSPlayer", spawnPosition1, Quaternion.identity);
            }
            else {
                PhotonNetwork.Instantiate("FPSPlayer", spawnPosition2, Quaternion.identity);
            }
            
        }
        
    }
}
