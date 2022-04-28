using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using ExitGames.Client.Photon;
public class ClosetDoorScript : MonoBehaviourPun
{
    public GameObject door;
    private const byte OPEN_CLOSET_ROOM_1_EVENT = 3;
    
    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }

    //Quitar listener al deshabilitar el gameObject
    private void OnDisable(){
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived;
    }

    //Este es el metodo que recibira el paquete, si el codigo es igual a 1, llamaremos a la funcion OpenDoor
    private void NetworkingClient_EventReceived(EventData obj){
        if(obj.Code == OPEN_CLOSET_ROOM_1_EVENT)
        {
            Destroy(door);
        }
    }
}
