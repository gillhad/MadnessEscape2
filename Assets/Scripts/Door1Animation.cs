using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using ExitGames.Client.Photon;
using MadnessEscape2.Assets.Scripts;

public class Door1Animation : MonoBehaviourPun
{

    public bool CheckcanBeOpened = true;

    [SerializeField] private Animator animator = null;

    /*Dejo esto comentado por si lo necesitamos en un futuro XD
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.door1CanBeOpened) {
            Debug.Log("la puerta se abre");
            animator.Play("OpenDoor",0,0.0f);
            Debug.Log("deberia abrirse");
            Collider.Destroy(this);
        }
    }*/

    //Si la variable estatica de GameManager, door1CanBeOpened esta en true, procedemos a abrir la puerta
    /*private void Update(){
        if (GameManager.door1CanBeOpened) {
            Debug.Log("la puerta se abre");
            animator.Play("OpenDoor",0,0.0f);
            Debug.Log("deberia abrirse");
            Collider.Destroy(this);
        }
    }*/

    private void Update(){
        //Checkeamos si la variable estatica del gameManager esta a true, si lo está llamamos a OpenDoor
        if (GameManager.door1CanBeOpened) {
            OpenDoor();
            GameManager.door1CanBeOpened = false;
        }

        
    }

    //Añadir listener al habilitar el gameoOject
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
        if(obj.Code == (uint)Events.OPEN_DOOR_1_EVENT)
        {      
            animator.Play("OpenDoor",0,0.0f);
            Collider.Destroy(this);
        }
    }

    //OpenDoor no abre la puerte, utiliza Photon para enviar el evento de abrir la puerta a todos los participantes
    private void OpenDoor(){
        RaiseEventOptions options = new RaiseEventOptions()
        {
            CachingOption = EventCaching.DoNotCache,
            Receivers = ReceiverGroup.Others
        };
        PhotonNetwork.RaiseEvent((byte)Events.OPEN_DOOR_1_EVENT, null, options, SendOptions.SendReliable);
    }

}
