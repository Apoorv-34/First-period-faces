using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Essential for Slider functionality

public class MainMenu : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainButtonsPanel;
    public GameObject settingsPanel;

    [Header("Scene Setup")]
    public string playSceneName = "First_Cut_Scene";

    // These variables hold the actual values used by the game
    public static float MouseSensitivity = 1f;

    void Start()
    {
        // Load saved settings on startup, or use defaults if it's the first time
        AudioListener.volume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        MouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 1f);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(playSceneName);
    }

    public void OpenSettings()
    {
        mainButtonsPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainButtonsPanel.SetActive(true);
    }

    // This performs the actual Volume change
    public void SetVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value); // Saves the setting
    }

    // This performs the actual Sensitivity change
    public void SetSensitivity(float value)
    {
        MouseSensitivity = value;
        PlayerPrefs.SetFloat("MouseSensitivity", value); // Saves the setting
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("game is quitting....");
    }
}