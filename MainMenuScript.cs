using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void PlayApp()
    {
        SceneManager.LoadScene(1);
    }

    public void AppQuit()
    {
        Application.Quit();
        Debug.Log("Çıkış yapıldı");
    }

    public void AppMenu()
    {
        SceneManager.LoadScene(0);
    }
}
