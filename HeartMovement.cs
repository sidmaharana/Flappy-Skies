using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMovement : MonoBehaviour
{
    public float speed = 5f; // Speed at which Heart moves

    // Update is called once per frame
    void Update()
    {
        // Move the Heart in the negative x direction
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
