using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2f;
    private float timer = 0f;
    public float heightOffset = 10f;
    public BirdScript birdScript; // Reference to BirdScript to access the score
    public GameObject heartPrefab; // Reference to the Heart prefab
    public float heartSpeed = 5f; // Speed at which Heart moves
    public int stopSpawningScore = 50; // Editable score at which pipes stop spawning
    public float heartOffset = 5f; // Offset for Heart's spawn position

    private bool heartSpawned = false; // Flag to track if Heart has been spawned

    // Start is called before the first frame update
    void Start()
    {
        // Optional: Check if the BirdScript reference is assigned
        if (birdScript == null)
        {
            Debug.LogError("BirdScript reference is not assigned in PipeSpawner.");
        }

        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (birdScript != null) // Ensure birdScript is not null before accessing it
        {
            // Stop spawning pipes if score reaches stopSpawningScore
            if (birdScript.score < stopSpawningScore)
            {
                // Increment timer by the time passed since last frame
                if (timer < spawnRate)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    // Spawn the pipe at the spawner's position and reset the timer
                    spawnPipe();
                    timer = 0f;
                }
            }

            // Spawn Heart if score reaches stopSpawningScore + 1 and it hasn't been spawned yet
            if (birdScript.score >= stopSpawningScore + 1 && !heartSpawned)
            {
                SpawnHeart();
                heartSpawned = true;
            }
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }

    void SpawnHeart()
    {
        // Instantiate the Heart at a position slightly to the right of the spawner
        GameObject heart = Instantiate(heartPrefab, new Vector3(transform.position.x + heartOffset, transform.position.y, 0), Quaternion.identity);

        // Optional: Ensure HeartMovement script is attached and set speed
        HeartMovement heartMovement = heart.GetComponent<HeartMovement>();
        if (heartMovement != null)
        {
            heartMovement.speed = heartSpeed; // Assign speed if needed
        }
    }

}
