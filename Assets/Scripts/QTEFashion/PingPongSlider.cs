using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PingPongSlider : MonoBehaviour
{
    [Header("References")]
    public Slider uiSlider;
    public TMP_Text timerText;
    public TMP_Text scoreText;

    [Header("Timing")]
    public float loopDuration = 1f;
    public float totalRunTime = 5f;

    [Header("Win Condition")]
    public int pointsToWin = 3;

    float elapsedTime;
    float timer;
    bool running;

    int score = 0;
    public Friendliness health;
    public GameObject panel;

    void OnEnable()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        elapsedTime = 0f;
        timer = 0f;
        running = true;
        score = 0;

        uiSlider.value = 0f;
        timerText.text = totalRunTime.ToString("0.0");
        timerText.color = Color.white;
        scoreText.text = $"Score: {score}/{pointsToWin}";
    }

    void Update()
    {
        if (!running) return;

        elapsedTime += Time.deltaTime;
        timer += Time.deltaTime;

        uiSlider.value = Mathf.PingPong(timer / loopDuration, 1f);

        float remainingTime = Mathf.Max(0f, totalRunTime - elapsedTime);
        timerText.text = remainingTime.ToString("0.0");

        if (remainingTime <= 1f)
        {
            timerText.color = Color.red;
        }

        if (elapsedTime >= totalRunTime)
        {
            Lose();
            panel.SetActive(false);
        }
    }

    // 🔹 Called by PerfectSnap
    public void AddPoint()
    {
        if (!running) return;

        score++;
        scoreText.text = $"Score: {score}/{pointsToWin}";

        if (score >= pointsToWin)
        {
            StartCoroutine(closePanel());
            health.GiveHealth(2);
        }
    }

    void Win()
    {
        running = false;
        timerText.text = "WIN!";
        Debug.Log("Player Wins!");
    }

    void Lose()
    {
        running = false;
        timerText.text = "FAIL";
        Debug.Log("Player Loses!");
    }

    private IEnumerator closePanel()
    {
        Win();
        yield return new WaitForSeconds(1);
        panel.SetActive(false);
    }
}
