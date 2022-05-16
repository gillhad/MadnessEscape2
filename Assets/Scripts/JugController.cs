using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugController : MonoBehaviour
{
    public GameObject jug;

    void OnMouseOver(){
        if(Input.GetMouseButtonDown(0) && GameManager.playerHasMorningStar){
            Destroy(jug);
        }
    }
}
