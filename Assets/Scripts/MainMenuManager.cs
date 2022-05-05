using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public static MainMenuManager Instance;
    [SerializeField] Menu[] menus;

    GameObject button1, button2, button3;
    SceneManager scene;

    void Awake()
    {
        Instance = this;
    }

    //Este método nos sirve para poder acceder a los menús por sus nombres declarados en la variable "menuName" 
    //del script Menu.cs. Por si queremos llamar a algún menú desde script

    //Los bucles controlan que solo haya un menú a la vez abierto.
    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menuName)
            {
                menus[i].Open();
            }
            else if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
    }


    //Con este método accedemos a través de objetos Menu del array menus
    //Por si queremos llamar a algún menú a traves de la herramienta de unity(OnClick event)
    public void OpenMenu(Menu menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
        menu.Open();
    }

    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }

    public void OnLoadTest1() {
        SceneManager.LoadScene(2);
    }
    public void OnLoadTest2() {
        SceneManager.LoadScene(3);
    }
    public void OnLoadTest3() {
        SceneManager.LoadScene(4);
    }













































    /*
    public void StartGame() {
        Debug.Log("iniciar");
        SceneManager.LoadScene(1);
    }

    public int target = 30;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;
    }

    void Update()
    {
        if (Application.targetFrameRate != target)
            Application.targetFrameRate = target;
    }
    */
}
