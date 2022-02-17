using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Function triggered when the 'PLAY' button is pressed
    public void PlayGame()
    {
        // Loads the scene of the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Function triggered when the 'QUIT' button is pressed
    public void QuitGame()
    {
        // Quits the application
        Application.Quit();
    }
}