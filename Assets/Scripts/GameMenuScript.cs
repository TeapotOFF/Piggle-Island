using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{
    public GameObject settingMenu;
    public GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }

    public void CloseButton()
    {
        Application.Quit();
    }

    public void ContinueButton()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void SettingButton()
    {
        settingMenu.SetActive(true);
    }
}
