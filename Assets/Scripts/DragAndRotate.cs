using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using ExitGames.Client.Photon;
using System.Linq;
using MadnessEscape2.Assets.Scripts;

public class DragAndRotate : MonoBehaviourPun
{
    private float _sensitivity;
     private Vector3 _mouseReference;
     private Vector3 _mouseOffset;
     private Vector3 _rotation; 
     private bool _isRotating;

      RaiseEventOptions options = new RaiseEventOptions()
        {
            CachingOption = EventCaching.DoNotCache,
            Receivers = ReceiverGroup.All
        };
     
     void Start ()
     {
         _sensitivity = 0.4f;
         _rotation = Vector3.zero;
     }
     
     void Update()
     {
         if(_isRotating)
         {
             // offset
             _mouseOffset = (Input.mousePosition - _mouseReference);
             
             // apply rotation
             _rotation.z = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;
             
             // rotate
             transform.Rotate(_rotation);
             
             // store mouse
             _mouseReference = Input.mousePosition;

            object data = _rotation.z;
            
            PhotonNetwork.RaiseEvent((byte)Events.ROTATE_ITEM, data, options, SendOptions.SendUnreliable);
         }
     }
     
     void OnMouseDown()
     {
         // rotating flag
         _isRotating = true;
         PhotonNetwork.RaiseEvent((byte)Events.ROCK_SOUND, null, options, SendOptions.SendUnreliable);
         
         // store mouse
         _mouseReference = Input.mousePosition;
         GetComponent<AudioSource>().Play();
         
     }
     
     void OnMouseUp()
     {
         // rotating flag
         _isRotating = false;
         GetComponent<AudioSource>().Stop();
          
     }
}
