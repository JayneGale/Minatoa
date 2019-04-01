using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    private Scene scene;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReallyQuit()
    {
        Debug.Log("Quit confirmation has been pressed");
        Application.Quit();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
}
