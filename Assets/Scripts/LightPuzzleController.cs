using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzleController : MonoBehaviour
{
    public  List<GameObject> button = new List<GameObject>();

    GameManager gameManager;

    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;
    public GameObject light5;
    public GameObject light6;

    public bool btnpress1;
    public bool btnpress2;
    public bool btnpress3;
    public bool btnpress4;
    public bool btnpress5;
    public bool btnpress6;

    float btnDown = 0.1f;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if (light1.GetComponent<ParticleSystem>().isPlaying
               && light2.GetComponent<ParticleSystem>().isPlaying
               && light3.GetComponent<ParticleSystem>().isPlaying
               && light4.GetComponent<ParticleSystem>().isPlaying
               && light5.GetComponent<ParticleSystem>().isPlaying
               && light6.GetComponent<ParticleSystem>().isPlaying)
        {
            gameManager.lightPuzzleSolved = true;
            gameManager.lightPuzzleSolution();
            Debug.Log("done");
        }


        if (btnpress1 && btnpress2 && btnpress3 && btnpress4 && btnpress5 && btnpress6)
        {

                Debug.Log("se apretaron todos los botones");
                btnpress1 = false;
                btnpress2 = false;
                btnpress3 = false;
                btnpress4 = false;
                btnpress5 = false;
                btnpress6 = false;
                button.ForEach(item => {
                    item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y + btnDown, item.transform.position.z);
                });
                
            
        }
    }
}
