using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using MadnessEscape2.Assets.Scripts;
using ExitGames.Client.Photon;

public class Palanca21 : MonoBehaviourPun
{
    public GameObject lever;
    public GameObject door21;
    public GameObject door22;

    

    
    static public bool up;

    //inicializar la palanca hacia arriba
    void Start()
    {
        up = true;
        lever.transform.Rotate(-60f, 0f, 0f);

    }

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }

    //Quitar listener al deshabilitar el gameObject
    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived;
    }

    private void NetworkingClient_EventReceived(EventData obj)
    {
        if (obj.Code == (uint)Events.DESTROY_DOORS_SECOND_ROOMS)
        {
            door21.SetActive(false);
            door22.SetActive(false);
        }
    }

    //cuando se pulse sobre la palanca se subira o se bajara, segun en el estado en el que esté
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (up)
            {
                lever.transform.Rotate(120f, 0, 0f);
                up = false;
                
                RaiseEventOptions options = new RaiseEventOptions()
                {
                    CachingOption = EventCaching.DoNotCache,
                    Receivers = ReceiverGroup.All
                };
                PhotonNetwork.RaiseEvent((byte)Events.DESTROY_DOORS_SECOND_ROOMS, null, options, SendOptions.SendReliable);

            }
            else if (!up)
            {

                lever.transform.Rotate(-120f, 0, 0f);
                up = true;
            }
        }
    }
}
