using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartMenuMenager : MonoBehaviour
{

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
