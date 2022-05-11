using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerNameManager : MonoBehaviour
{
    [SerializeField] TMP_InputField usernameInput;

    public void OnUserNameInputValueChanged()
    {
        PhotonNetwork.NickName = usernameInput.text;
    }
}
