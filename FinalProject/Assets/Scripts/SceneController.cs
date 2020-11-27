using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void Update()
    {
        SceneCheck();
    }

    public void SceneCheck()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            if (Input.anyKeyDown)
            {
                EnterGame();
            }
        }
        else if (SceneManager.GetActiveScene().name == "ResultScene")
        {
            if (Input.anyKeyDown)
            {
                MainMenu();
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void EnterGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
