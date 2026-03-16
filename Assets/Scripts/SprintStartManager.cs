using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class SprintStartMinigame : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI statusText;
    public GameObject instructionBox;
    public TextMeshProUGUI instructionText;

    [Header("Timing")]
    public float readyTime = 0.7f;
    public float setTimeMin = 0.4f;
    public float setTimeMax = 1.0f;
    public float reactionWindow = 0.6f;

    [Header("Progression")]
    public int requiredWins = 3;
    private int currentStreak = 0;

    [Header("Scene")]
    public string winSceneName;

    private bool canReact = false;
    private bool isGameOver = false;
    private bool pressedThisTurn = false;

    void Start()
    {
        UpdateInstructionText();
        StartCoroutine(GameLoop());
    }

    void Update()
    {
        if (isGameOver) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canReact && !pressedThisTurn)
            {
                SuccessfulHit();
            }
            else
            {
                ResetProgress("FALSE START!");
            }
        }
    }

    IEnumerator GameLoop()
    {
        while (!isGameOver)
        {
            canReact = false;
            pressedThisTurn = false;

            // 1. READY
            statusText.text = "READY";
            yield return new WaitForSeconds(readyTime);

            // 2. SET
            statusText.text = "SET";
            yield return new WaitForSeconds(Random.Range(setTimeMin, setTimeMax));

            // 3. GO!
            statusText.text = "GO!";
            canReact = true;

            // Wait for reaction window
            float timer = 0;
            while (timer < reactionWindow)
            {
                if (pressedThisTurn) break; // Exit wait early if they hit it
                timer += Time.deltaTime;
                yield return null;
            }

            // If they didn't press space at all during the window
            if (!pressedThisTurn && !isGameOver)
            {
                ResetProgress("TOO SLOW!");
            }

            canReact = false;
            statusText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SuccessfulHit()
    {
        pressedThisTurn = true;
        currentStreak++;
        UpdateInstructionText();

        if (currentStreak >= requiredWins)
        {
            Win();
        }
        else
        {
            statusText.text = "NICE! (" + currentStreak + "/" + requiredWins + ")";
        }
    }

    void ResetProgress(string reason)
    {
        currentStreak = 0;
        UpdateInstructionText();
        statusText.text = reason;

        // Stop the loop briefly to let them see why they failed
        StopAllCoroutines();
        StartCoroutine(RestartAfterDelay());
    }

    IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(GameLoop());
    }

    void UpdateInstructionText()
    {
        if (instructionText != null)
        {
            instructionText.text = $"Streak: {currentStreak}/{requiredWins}\nPress SPACE on GO!";
        }
    }

    void Win()
    {
        isGameOver = true;
        statusText.text = "CHAMPION!";
        if (!string.IsNullOrEmpty(winSceneName))
        {
            SceneManager.LoadScene(winSceneName);
        }
    }
}