using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame ()
    {
        // Loads GameScene
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        // Quits game
        Debug.Log("Quit");
        Application.Quit();
    }

}
