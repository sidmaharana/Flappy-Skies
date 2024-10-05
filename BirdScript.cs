using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for accessing UI elements

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float FlapStrength = 10f; // Default value for FlapStrength
    public Text scoreText; // Reference to the UI Text component for the score
    public int score = 0; // Score is now public so PipeSpawner can access it

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the Rigidbody2D is assigned
        if (myRigidbody == null)
        {
            Debug.LogError("Rigidbody2D is not assigned in the Inspector.");
        }

        // Enable bird physics right away
        myRigidbody.simulated = true;

        // Initialize score text
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        // Check for bird flap input using Space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Apply upward force to the bird
            if (myRigidbody != null)
            {
                myRigidbody.velocity = Vector2.up * FlapStrength;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the ColumnSpawner
        if (collision.gameObject.CompareTag("ColumnSpawner"))
        {
            // Handle collision with ColumnSpawner (no restart)
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bird has collided with the ScoreTrigger
        if (other.CompareTag("ScoreTrigger"))
        {
            IncreaseScore();
        }
    }

    private void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
