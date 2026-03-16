using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game Rules")]
    public int maxTries = 10;
    public int requiredSuccess = 3;

    [Header("Scene Names")]
    public string winSceneName;
    public string loseSceneName;

    [Header("UI")]
    public TextMeshProUGUI statusText;

    int currentTries = 0;
    int currentSuccess = 0;
    bool gameEnded = false;

    void Start()
    {
        UpdateUI();
    }

    public void RegisterThrow()
    {
        if (gameEnded) return;

        currentTries++;
        UpdateUI();

        // LOSE condition
        if (currentTries >= maxTries && currentSuccess < requiredSuccess)
        {
            EndGame(false);
        }
    }

    public void RegisterSuccess()
    {
        if (gameEnded) return;

        currentSuccess++;
        UpdateUI();

        // WIN immediately on required success
        if (currentSuccess >= requiredSuccess)
        {
            EndGame(true);
        }
    }

    void UpdateUI()
    {
        if (statusText == null) return;

        statusText.text =
            "Tries: " + currentTries + "/" + maxTries +
            "   |   Success: " + currentSuccess + "/" + requiredSuccess;
    }

    void EndGame(bool win)
    {
        gameEnded = true;
        Time.timeScale = 1f;

        if (win)
        {
            SceneManager.LoadScene(winSceneName);
        }
        else
        {
            SceneManager.LoadScene(loseSceneName);
        }
    }
}
