using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class SceneChanger : MonoBehaviour
{
    public string endSceneName = "EndScene"; // Name of the EndScene to switch to
    public string level2SceneName = "Level2"; // Name of Level2 scene to switch to

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the GameObject is named "Bird" and collides with "DownBorder"
        if (gameObject.name == "Bird" && collision.gameObject.name == "DownBorder")
        {
            // Change to EndScene when "Bird" collides with "DownBorder"
            SceneManager.LoadScene(endSceneName);
        }

        // Check if the GameObject is named "Bird" and collides with "UpBorder"
        if (gameObject.name == "Bird" && collision.gameObject.name == "UpBorder")
        {
            // Change to EndScene when "Bird" collides with "UpBorder"
            SceneManager.LoadScene(endSceneName);
        }

        // Check if the GameObject is named "Bird" and collides with a GameObject tagged "Pipe"
        if (gameObject.name == "Bird" && collision.gameObject.CompareTag("Pipe"))
        {
            // Change to EndScene when "Bird" collides with any GameObject tagged "Pipe"
            SceneManager.LoadScene(endSceneName);
        }

        // Check if the GameObject is named "Bird" and collides with a GameObject tagged "Heart"
        if (gameObject.name == "Bird" && collision.gameObject.CompareTag("Heart"))
        {
            // Change to Level2 when "Bird" collides with any GameObject tagged "Heart"
            SceneManager.LoadScene(level2SceneName);
        }
    }
}
