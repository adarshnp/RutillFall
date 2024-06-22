using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public AudioSource audioManager;
    private void Start()
    {
        highScore.text = "High Score : " + PlayerPrefs.GetString("High Score");
        SetVolume(1f);
    }
    public void OnPlayButton()
    {
        SceneManager.LoadScene(2);
    }
    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
        audioManager.volume = volume;
    }
}
