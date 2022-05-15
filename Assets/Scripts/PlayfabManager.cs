using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using Photon.Pun;

public class PlayfabManager : MonoBehaviour
{

    PlayerNameManager pnm;
    // Start is called before the first frame update
    void Start()
    {
        Login();

    }


    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);

    }

    void OnSuccess(LoginResult result)
    {
        Debug.Log("Succesful login");

    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderboard(float minutes, float seconds)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName = "Tiempo",
                    Value = minutes + seconds/10
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Succesfull leaderboard sent");
    }

    public void GetLeaderboard()
    {
        Debug.Log("funciona");
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Tiempo",
            StartPosition = 0,
            MaxResultsCount = 5
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeadeboardGet, OnError);
    }

    void OnLeadeboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }

    public void SubmitNameBtn()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = PhotonNetwork.NickName,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
        Debug.Log(request);
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result){
        
    }


}
