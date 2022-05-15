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
        else
        {
            Destroy(gameObject);
        }
    }

    public override void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        Vector3 spawnPosition1 = new Vector3(4f, 2f, 4f);
        Vector3 spawnPosition2 = new Vector3(8f, 2f, 25f);
        Vector3 spawnRoom3 = new Vector3(27f, 2f, 10f);
        Vector3 spawnRoom2 = new Vector3(18f, 2f, 10f);
        Vector3 spawnRoom22 = new Vector3(20f, 2f, 20f);
        Vector3 spawnRoom32 = new Vector3(27f, 2f, 25f);
        Vector3[] positions = new[] { spawnPosition1, spawnPosition2 };

        if (PhotonNetwork.InRoom)
        {

            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate("FPSPlayer", spawnPosition1, Quaternion.identity);
            }
            else
            {
                PhotonNetwork.Instantiate("FPSPlayer", spawnPosition2, Quaternion.identity);
            }

        }
    }
}
