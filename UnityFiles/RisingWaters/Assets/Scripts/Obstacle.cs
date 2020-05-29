using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Player takes damage
            collision.GetComponent<PlayerController>().health -= damage;
            Debug.Log(collision.GetComponent<PlayerController>().health);
        }
    }
}
