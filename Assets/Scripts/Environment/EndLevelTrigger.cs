using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTrigger : MonoBehaviour
{
    // The name of the scene to load when the player reaches the end of the level
    public string nextSceneName;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            // Checks to see if the next scene exists before goign to load into it
            if (Application.CanStreamedLevelBeLoaded(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                // Reloads the current scene if the next scene doesn't exist
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}