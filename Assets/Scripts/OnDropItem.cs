using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnDropItem : MonoBehaviour, IDropHandler
{
    GameManager gameManager;
    int current3ml;
    int current5ml;
    int current8ml;

    private void Awake()
    {
        //Debug.Log(gameManager.ml3);
        //current3ml = gameManager.ml3;
        //current5ml = gameManager.ml5;
        //current8ml = gameManager.ml8;
        //Debug.Log(current3ml);
    }
    public void OnDrop(PointerEventData eventData)
    {
        
        Debug.Log("droped");
        if (eventData.pointerDrag != null)
        {
            Debug.Log(eventData.pointerDrag.GetComponentInChildren<Text>().text); //coge el objeto dragged
            Debug.Log(GetComponentInChildren<Text>().text); //coge el texto del drop
            int potion1 = int.Parse(eventData.pointerDrag.GetComponentInChildren<Text>().text);
            int potion2 = int.Parse(GetComponentInChildren<Text>().text);
            if (int.Parse(GetComponentInChildren<Text>().text) < int.Parse(eventData.pointerDrag.GetComponentInChildren<Text>().text))
            {
                Debug.Log("a" + int.Parse(GetComponentInChildren<Text>().name));
                for (int i = int.Parse(GetComponentInChildren<Text>().text); i < int.Parse(GetComponentInChildren<Text>().name); i++)
                {
                    potion1 -= 1;
                    potion2 += 1;
                    GetComponentInChildren<Text>().text = potion2.ToString();
                    eventData.pointerDrag.GetComponentInChildren<Text>().text = potion1.ToString();
                    if (potion1 == 0) {
                        break;
                    }
                }
            }
            else { 
            Debug.Log("movimiento no permitido");}
        }
    }
}
