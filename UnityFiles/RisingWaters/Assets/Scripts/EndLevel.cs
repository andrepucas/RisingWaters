using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player hits an obstacle
        if (collision.CompareTag("Player"))
        {
            player.gameObject.SetActive(false);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
