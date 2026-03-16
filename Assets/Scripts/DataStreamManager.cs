using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DataStreamManager : MonoBehaviour
{
    [Header("Lights")]
    public Image[] lights;
    public float flashDelay = 0.6f;

    [Header("UI")]
    public TMP_Text winCounterText;
    public TMP_Text resultText;

    [Header("Game Rules")]
    public int winLevel = 4;

    [Header("Scene Control")]
    public string successSceneName;   // scene to load on success
    public float endDelay = 2f;        // delay before restart / scene load

    private List<int> pattern = new List<int>();
    private List<int> playerInput = new List<int>();

    private bool playerTurn = false;
    private bool gameOver = false;

    private int winCount = 0;

    void Start()
    {
        winCount = 0;
        gameOver = false;

        if (resultText != null)
            resultText.gameObject.SetActive(false);

        UpdateWinCounter();
        StartCoroutine(StartSequence());
    }

    IEnumerator StartSequence()
    {
        if (gameOver) yield break;

        playerTurn = false;
        playerInput.Clear();

        pattern.Add(Random.Range(0, lights.Length));

        yield return new WaitForSeconds(1f);

        foreach (int i in pattern)
        {
            yield return FlashLight(i);
        }

        playerTurn = true;
    }

    IEnumerator FlashLight(int index)
    {
        if (lights[index] == null) yield break;

        Image img = lights[index];
        Color original = img.color;

        img.color = Color.white;
        yield return new WaitForSeconds(flashDelay);

        img.color = original;
        yield return new WaitForSeconds(0.2f);
    }

    public void PlayerPress(int index)
    {
        if (!playerTurn || gameOver) return;

        playerInput.Add(index);

        // ❌ LOSE CONDITION
        if (playerInput[playerInput.Count - 1] != pattern[playerInput.Count - 1])
        {
            GameLost();
            return;
        }

        // ✅ Completed current sequence
        if (playerInput.Count == pattern.Count)
        {
            winCount++;
            UpdateWinCounter();

            // 🏆 WIN CONDITION
            if (winCount >= winLevel)
            {
                GameWon();
                return;
            }

            StartCoroutine(StartSequence());
        }
    }

    void GameWon()
    {
        gameOver = true;
        playerTurn = false;

        Debug.Log("🏆 UPLOAD COMPLETE");

        if (resultText != null)
        {
            resultText.gameObject.SetActive(true);
            resultText.text = "UPLOAD COMPLETE";
            resultText.color = Color.green;
        }

        // ▶ Load next scene after delay
        StartCoroutine(LoadSuccessScene());
    }

    void GameLost()
    {
        gameOver = true;
        playerTurn = false;

        Debug.Log("❌ UPLOAD FAILED");

        if (resultText != null)
        {
            resultText.gameObject.SetActive(true);
            resultText.text = "UPLOAD FAILED";
            resultText.color = Color.red;
        }

        // 🔁 Restart game after delay
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(endDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator LoadSuccessScene()
    {
        yield return new WaitForSeconds(endDelay);

        if (!string.IsNullOrEmpty(successSceneName))
            SceneManager.LoadScene(successSceneName);
        else
            Debug.LogWarning("Success scene name not set!");
    }

    void UpdateWinCounter()
    {
        if (winCounterText != null)
            winCounterText.text = "UPLOAD LEVEL : " + winCount;
    }
}
