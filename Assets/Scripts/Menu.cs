using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string menuName;

    public bool open;
    public void Open()
    {
        open = true;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        open = false;
        gameObject.SetActive(false);
    }

    public void OnLoadTest1()
    {
        SceneManager.LoadScene(2);
    }
    public void OnLoadTest2()
    {
        SceneManager.LoadScene(3);
    }
    public void OnLoadTest3()
    {
        SceneManager.LoadScene(4);
    }
}
