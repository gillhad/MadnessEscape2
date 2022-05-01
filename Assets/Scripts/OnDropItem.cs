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
        
        Debug.Log(current3ml);
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



                if (GetComponentInChildren<Text>().text != "0")
                {
                    GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/GreenPotion");
                }
                else
                {
                    GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/EmptyPotion");
                }
                if (eventData.pointerDrag.GetComponentInChildren<Text>().text != "0")
                {
                    eventData.pointerDrag.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/GreenPotion");
                }
                else
                {
                    eventData.pointerDrag.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprites/EmptyPotion");
                }

                Debug.Log("valores de las pociones");
                Debug.Log(GameManager.ml3);
                Debug.Log(GameManager.ml5);
                Debug.Log(GameManager.ml8);

                //Comrpobamos el valor del objeto donde se recibe líquido
                if (GetComponentInChildren<Text>().name == "3")
                {
                    GameManager.ml3 = int.Parse(GetComponentInChildren<Text>().text);
                }
                else if (GetComponentInChildren<Text>().name == "5")
                {
                    GameManager.ml5 = int.Parse(GetComponentInChildren<Text>().text);
                }
                else
                {
                    GameManager.ml8 = int.Parse(GetComponentInChildren<Text>().text);
                }

                //Comprobamos el valor de donde tiramos líquido
                if (eventData.pointerDrag.GetComponentInChildren<Text>().name == "3")
                {
                    GameManager.ml3 = int.Parse(eventData.pointerDrag.GetComponentInChildren<Text>().text);
                }
                else if (eventData.pointerDrag.GetComponentInChildren<Text>().name == "5")
                {
                    GameManager.ml5 = int.Parse(eventData.pointerDrag.GetComponentInChildren<Text>().text);
                }
                else
                {
                    GameManager.ml8 = int.Parse(eventData.pointerDrag.GetComponentInChildren<Text>().text);
                }
               
        }
    }
}
