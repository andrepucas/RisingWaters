using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private MainMenu menu;
    private PlayerController player;

    public static bool GameIsPaused = false;

    public GameObject gameOverUI;

    private void Start()
    {
        gameOverUI.SetActive(false);
        GameIsPaused = false;


        player = FindObjectOfType<PlayerController>();
        menu = FindObjectOfType<MainMenu>();
    }

    public void Update()
    {
        if (player.isDead == true)
        {
            if (GameIsPaused)
            {
                Restart();
            }
            else
            {
                Pause();
            }
            player.isDead = false;
        }
    }

    public void Restart()
    {
        gameOverUI.SetActive(false);
        //Time.timeScale = 1f;

        GameIsPaused = false;
        player.isDead = false;

        SceneManager.LoadScene(menu.sceneIndex);
    }

    public void Pause()
    {
        //SceneManager.LoadScene("PauseMenu");
        gameOverUI.SetActive(true);
        //Time.timeScale = 0f;

        GameIsPaused = true;
        player.isDead = false;
    }

    public void Menu()
    {
        GameIsPaused = false;
        player.isDead = false;

        //Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
