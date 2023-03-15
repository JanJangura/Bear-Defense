using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI Kills;
    public TextMeshProUGUI Waves;

    public TextMeshProUGUI KillResults;
    public TextMeshProUGUI WavesResults;

    public GameObject pauseMenu;
    public static bool isPaused;

    private void Start()
    {
        Kills.text = "HIGHEST KILLS: " + PlayerPrefs.GetInt("KILLS");
        Waves.text = "HIGHEST WAVES: " + PlayerPrefs.GetInt("WAVES");
        KillResults.text = "RESULT KILLS: " + PlayerPrefs.GetInt("CURRENTKILLS");
        WavesResults.text = "RESULT WAVES: " + PlayerPrefs.GetInt("CURRENTWAVES");
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        isPaused = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GamePlay");
        isPaused = false;
    }
}
