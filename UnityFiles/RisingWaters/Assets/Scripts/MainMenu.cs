using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    int sceneIndex;
    private PlayerController player;

    public void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        player = FindObjectOfType<PlayerController>();
    }


    public void PlayGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void PlayEndless()
    {
        SceneManager.LoadScene("Endless");
    }

    public void ArcadeMsg()
    {
        SceneManager.LoadScene("ArcadeMsg");
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void MenuMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player hits an obstacle
        if (collision.CompareTag("Player"))
        {
            LoadNextLevel();
        }
    }
}
