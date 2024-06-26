using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using MadnessEscape2.Assets.Scripts;
using ExitGames.Client.Photon;

public class BookManager : MonoBehaviourPun
{
    public List<GameObject> books;
    public List<GameObject> huecos;
    public static bool solved = false;
    private static GameManager gameManager;
    Vector3 position1;
    Vector3 position2;
    Vector3 position3;
    Vector3 position4;
    Vector3 position5;
    Vector3 position6;

    private void Awake()
    {
        position1 = books[0].transform.position;
        position2 = books[1].transform.position;
        position3 = books[2].transform.position;
        position4 = books[3].transform.position;
        position5 = books[4].transform.position;
        position6 = books[5].transform.position;
    }

    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    }

    private void Update()
    {
        if (!solved)
        {
            int count = 0;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].GetComponent<RectTransform>().anchoredPosition == huecos[i].GetComponent<RectTransform>().anchoredPosition)
                {
                   count++;
                }
                else
                {

                };
            }
            if (count == 6)
            {
                Debug.Log("solved");
                solved = true;
                gameManager.bookSolved();
            }
        }
    }

    public void onReset() {
          books[0].transform.position = position1;
          books[1].transform.position = position2;
          books[2].transform.position = position3;
          books[3].transform.position = position4;
          books[4].transform.position = position5;
          books[5].transform.position = position6;
    }

}


