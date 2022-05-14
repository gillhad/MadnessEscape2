using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightButtonController : MonoBehaviour
{
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;
    public GameObject light5;
    public GameObject light6;

    LightPuzzleController lightPuzzleController;


    private void Start()
    {
        lightPuzzleController = FindObjectOfType<LightPuzzleController>();
    }
    float btnDown = 0.5f;

    private void OnMouseDown()
    {
        if (this.gameObject.name == "btn1" && !lightPuzzleController.btnpress1)
        {
            lightPuzzleController.btnpress1 = true;        
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - btnDown, this.transform.position.z);
            if (light2.GetComponent<ParticleSystem>().isPlaying)
            {
                light2.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                light2.GetComponent<ParticleSystem>().Play();
                FindObjectOfType<LightPuzzleController>().GetComponent<AudioSource>().Play();

            }

        }

        if (this.gameObject.name == "btn2" && !lightPuzzleController.btnpress2)
        {

            lightPuzzleController.btnpress2 = true;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - btnDown, this.transform.position.z);

            if (light1.GetComponent<ParticleSystem>().isPlaying)
            {
                light1.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                light1.GetComponent<ParticleSystem>().Play();
            }
            if (light3.GetComponent<ParticleSystem>().isPlaying)
            {
                light3.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                light3.GetComponent<ParticleSystem>().Play();
            }
        }

        if (this.gameObject.name == "btn3" && !lightPuzzleController.btnpress3)
        {

            lightPuzzleController.btnpress3 = true;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - btnDown, this.transform.position.z);
            if (light2.GetComponent<ParticleSystem>().isPlaying)
            {
                light2.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                light2.GetComponent<ParticleSystem>().Play();
            }
            if (light4.GetComponent<ParticleSystem>().isPlaying)
            {
                light4.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                light4.GetComponent<ParticleSystem>().Play();
            }
        }
        if (this.gameObject.name == "btn4" && !lightPuzzleController.btnpress4)
        {

            lightPuzzleController.btnpress4 = true;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - btnDown, this.transform.position.z);
            if (light3.GetComponent<ParticleSystem>().isPlaying)
            {
                light3.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                light3.GetComponent<ParticleSystem>().Play();
            }
            if (light5.GetComponent<ParticleSystem>().isPlaying)
            {
                light5.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                light5.GetComponent<ParticleSystem>().Play();
            }
        }

        if (this.gameObject.name == "btn5" && !lightPuzzleController.btnpress5)
        {

            lightPuzzleController.btnpress5 = true;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - btnDown, this.transform.position.z);
            if (light4.GetComponent<ParticleSystem>().isPlaying)
            {
                light4.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                light4.GetComponent<ParticleSystem>().Play();
            }
            if (light6.GetComponent<ParticleSystem>().isPlaying)
            {
                light6.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                light6.GetComponent<ParticleSystem>().Play();
            }
        }
        if (this.gameObject.name == "btn6" && !lightPuzzleController.btnpress6)
        {

            lightPuzzleController.btnpress6 = true;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - btnDown, this.transform.position.z);
            if (light5.GetComponent<ParticleSystem>().isPlaying)
            {
                light5.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                light5.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
