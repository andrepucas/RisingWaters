using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private PlayerController player;
    private MainMenu menu;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        menu = FindObjectOfType<MainMenu>();
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player hits an obstacle
        if (collision.CompareTag("Player"))
        {
            menu.sceneIndex += 1;
            player.gameObject.SetActive(false);
            SceneManager.LoadScene(menu.sceneIndex);
        }
    }
}
