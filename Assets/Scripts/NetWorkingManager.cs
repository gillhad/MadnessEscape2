using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetWorkingManager : MonoBehaviourPunCallbacks
{
    public Button multiplayerButton;


    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        multiplayerButton.interactable = true;
    }

    public void FindMatch() {
        Debug.Log("Buscando sala");
        PhotonNetwork.JoinRandomRoom();

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        MakeRoom();
    }

    private void MakeRoom() {
        int randomRoomName = Random.Range(0, 5000);
        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = true,
            MaxPlayers = 2,
            IsOpen = true,
            PublishUserId = true
        };

        PhotonNetwork.CreateRoom($"{randomRoomName}", roomOptions);
        Debug.Log($"sala creada: {randomRoomName}");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("cargando escena de juego");
        PhotonNetwork.LoadLevel(1);
    }

}
