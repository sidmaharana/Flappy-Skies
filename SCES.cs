using UnityEngine;
using UnityEngine.SceneManagement;

public class SCES : MonoBehaviour
{
    void Update()
    {
        // Check if the Enter key is pressed
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Load the "Start" scene
            SceneManager.LoadScene("Start");
        }
    }
}
