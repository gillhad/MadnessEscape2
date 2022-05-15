using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using TMPro;



public class NetWorkingManager : MonoBehaviourPunCallbacks
{
    public static NetWorkingManager Instance;
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] Transform roomListContent;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject roomListItemPrefab;
    [SerializeField] GameObject playerListItemPrefab;
    [SerializeField] GameObject startGameButton;


    void Awake()
    {
        Instance = this;
    }
    //Se conecta al servidor (al Master)

    void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            Debug.Log("Connecting to Master");
            PhotonNetwork.ConnectUsingSettings();
        }

    }

    //Una vez estemos conectados al servidor. Hay que entrar en una lobby para poder crear salas
    //y todas las movidas del multijugador
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        MainMenuManager.Instance.OpenMenu("MainMenu");
        Debug.Log("Joined lobby");

    }

    public void CreateRoom()
    {
        //Asegurarnos que se introducen valores en le campo
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text);
        MainMenuManager.Instance.OpenMenu("LoadingMenu");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined into a room");
        MainMenuManager.Instance.OpenMenu("RoomMenu");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;

        Player[] players = PhotonNetwork.PlayerList;


        foreach (Transform child in playerListContent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < players.Length; i++)
        {
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
        }

        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room Creation Failed: " + message;
        Debug.LogError("Room Creation Failed: " + message);
        MainMenuManager.Instance.OpenMenu("ErrorMenu");

    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MainMenuManager.Instance.OpenMenu("LoadingMenu");
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MainMenuManager.Instance.OpenMenu("LoadingMenu");


    }

    public override void OnLeftRoom()
    {
        Debug.Log("Room destroyed");
        MainMenuManager.Instance.OpenMenu("MainMenu");

    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }
        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
                continue;
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
    }

    public void StartGame()
    {
        if (PhotonNetwork.PlayerList.Length == 2)
        {
            PhotonNetwork.LoadLevel(1);
            Debug.Log("Game started");
        }

    }






















































    /*
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
        string prueba = "prueba";
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
*/
}
