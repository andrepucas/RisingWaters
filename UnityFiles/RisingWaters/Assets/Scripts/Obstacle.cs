using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
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
            // Loses 1HP and slows down.
            player.health   -= 1;
            player.moveSpeed = player.speedInitial;

            Debug.Log($"Slowed Down. Health = {player.health}");
        }

        // Player dies
        if (player.health == 0)
        {
            StartCoroutine(player.PlayerDeath());
        }
    }
}
