
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenuPanel");
    }

    public void settingsMenu()
    {
        SceneManager.LoadScene("SettingsMenuPanel");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
