using UnityEngine;
using TMPro;
using System;
public class TimeManager : MonoBehaviour
{
    private float timer;
    private float speed;
    private int subseconds;
    private int seconds;

    public TextMeshProUGUI lastTimer;
    public TextMeshProUGUI currentTimer;
    public TextMeshProUGUI highScore;
    public string lastSurvivalTime;
    public bool timerOn;
    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (timerOn && !HealthManager.GameIsPaused)
        {
            timer += Time.deltaTime * speed;
            //subseconds
            subseconds = Mathf.FloorToInt((timer % 1000)/10);
            //seconds
            seconds = Mathf.FloorToInt((timer) / 1000);
            currentTimer.text = seconds.ToString("00") + ":" + subseconds.ToString("00");
        }    
    }
    public void UpdateCurrentScoreInPauseMenu()
    {
        if (HealthManager.GameIsPaused)
        {
            PlayerPrefs.SetString("Current Score", currentTimer.text);
        }
    }
    void ResetTimer()
    {
        timer = 0;
        speed = 1000;
        seconds = 0;
        subseconds = 0;
        currentTimer.text = seconds.ToString("000") + ":" + subseconds.ToString("00");
        lastTimer.text = "Last Score :" + PlayerPrefs.GetString("Last Score", "00:00");
        highScore.text = "High Score :" + PlayerPrefs.GetString("High Score", "00:00");
        timerOn = true;
    }
    public void exportLastSurvivalTime()
    {
        timerOn = false;
        lastSurvivalTime = seconds.ToString("00") + ":" + subseconds.ToString("00");
        PlayerPrefs.SetString("Last Score", lastSurvivalTime);
        HighScoreManager();
    }
    public void HighScoreManager()
    {
        string _highScore = PlayerPrefs.GetString("High Score", "00:00");
        if (!string.IsNullOrEmpty(_highScore))
        {
            string[] highscoreArray = new string[2];
            highscoreArray = _highScore.Split(':');
            int highScoreSeconds = Int32.Parse(highscoreArray[0]);
            int highScoreSubSeconds = Int32.Parse(highscoreArray[1]);
            if (highScoreSeconds <= seconds)
            {
                PlayerPrefs.SetString("High Score", lastSurvivalTime);
            }
        }
    }
}
