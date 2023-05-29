using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMainMenu : MonoBehaviour
{

    private void Update()
    {
        // Gets input for escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoMainMenu();
        }
    }
    public void GoMainMenu()
    {
        // Loads MainMenu
        SceneManager.LoadScene(0);
    }
}
