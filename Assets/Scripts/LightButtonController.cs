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
    private void OnMouseDown()
    {
        if (this.gameObject.name == "btn1")
        {
            if (light2.GetComponent<ParticleSystem>().isPlaying)
            {
                light2.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                light2.GetComponent<ParticleSystem>().Play();
            }
            if (light3.GetComponent<ParticleSystem>().isPlaying)
            {
                light4.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                light4.GetComponent<ParticleSystem>().Play();
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
    }
}
