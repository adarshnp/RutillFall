using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    public TimeManager tm;
    void start()
    {
        pauseMenuUI.SetActive(false);
    }
    public void Pause()
    {
        HealthManager.GameIsPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        tm.UpdateCurrentScoreInPauseMenu();
        score.text = "Your Score " + PlayerPrefs.GetString("Current Score", "00:00");
        highScore.text = "High Score " + PlayerPrefs.GetString("High Score", "00:00");
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        HealthManager.GameIsPaused = false;
        pauseMenuUI.SetActive(false);
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