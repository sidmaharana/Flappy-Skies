using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
}
