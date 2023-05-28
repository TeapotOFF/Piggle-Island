using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenuScript : MonoBehaviour
{
    public void CloseButton()
    {
        Application.Quit();
    }

    public void StartNewGameButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
