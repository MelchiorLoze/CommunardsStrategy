using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Function triggered when the 'RETRY' button is pressed
    public void RestartGame()
    {
        // Loads the scene of the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Function triggered when the 'MENU' button is pressed
    public void ComeBackToMainMenu()
    {
        // Loads the scene of the main menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}