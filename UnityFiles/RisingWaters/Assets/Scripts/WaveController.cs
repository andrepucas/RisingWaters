using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    private PlayerController    player;
    private GameObject          wave;

    // Reference Vectors
    private Vector3 inCamera;
    private Vector3 offCamera;
    private Vector3 wavePosition;
    private Vector3 playerPosition;

    // Dictates if the wave should be on the screen
    private bool isVisible;

    // Velocity of the wave moving in or out of the screen
    [SerializeField] private float waveSpeedOut = 10f;
    [SerializeField] private float waveSpeedIn = 20f;
                     private float waveSpeedFinal;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        wave = GameObject.FindWithTag("Wave");

        // Positions relative to the Main Camera
        inCamera        = new Vector3 (-310, -7.8f, 10);
        offCamera       = new Vector3 (-330, -7.8f, 10);
        playerPosition  = new Vector3 (0, -7.8f, 10);
    }

    // Update is called once per frame
    void Update()
    {
        // Updates wavePosition Vector with the current position of the wave
        wavePosition = wave.transform.localPosition;

        // Checks if the wave should be on the screen or not
        if (player.moveSpeed == player.speedTerminal) 
        {
            isVisible = false;
        }
        else 
        {
            isVisible = true;
        }
        
        // Moves wave
        if (isVisible)
        {
            // On screen, behind the player
            if (player.health > 0)
            {
                wave.transform.localPosition = Vector3.MoveTowards(wavePosition, inCamera, (waveSpeedIn * Time.deltaTime));
            }

            // On screen, over player
            if (player.health == 0)
            {
                waveSpeedFinal = player.moveSpeed;
                wave.transform.localPosition = Vector3.MoveTowards(wavePosition, playerPosition, (waveSpeedFinal * Time.deltaTime));
            }

        }

        // Off screen 
        else
        {
            wave.transform.localPosition = Vector3.MoveTowards(wavePosition, offCamera, (waveSpeedOut * Time.deltaTime));
        }
    }
}
