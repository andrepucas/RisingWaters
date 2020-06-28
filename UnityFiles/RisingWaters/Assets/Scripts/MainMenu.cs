using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void PlayEndless()
    {
        SceneManager.LoadScene("Endless");
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void MenuMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Creddits()
    {
        SceneManager.LoadScene("Creddits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
