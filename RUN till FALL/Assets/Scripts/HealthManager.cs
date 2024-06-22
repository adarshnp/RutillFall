using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static bool GameIsPaused;
    private int health; 
    public TextMeshProUGUI lifeCount;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    public GameObject finishMenuUI;
    public TimeManager tm;
    public AudioSource audioManager;
    void Start()
    {
        finishMenuUI.SetActive(false);
        GameIsPaused = false;
        health = 2;
        lifeCount.text = health.ToString();
        float volume = PlayerPrefs.GetFloat("volume");
        audioManager.volume = volume;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obstacle"))
        {
            Destroy(other.gameObject);
        }
    }
    public void Conclusion()
    {
        HealthManager.GameIsPaused = true;
        finishMenuUI.SetActive(true);
        Time.timeScale = 0f;
        tm.UpdateCurrentScoreInPauseMenu();
        score.text = "Your Score " + PlayerPrefs.GetString("Current Score", "00:00");
        highScore.text = "High Score " + PlayerPrefs.GetString("High Score", "00:00");
    }
    public void ChangeHealth()
    {
        if (!GameIsPaused)
        {
            if (health > 1)
            {
                health--;
                lifeCount.text = health.ToString();
            }
            else
            {
                health = 0;
                lifeCount.text = health.ToString();
                GetComponent<TimeManager>().exportLastSurvivalTime();
                Conclusion();
            }
        }
    }
}
