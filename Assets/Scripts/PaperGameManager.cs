using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PaperGameManager : MonoBehaviour
{
    public Transform paper;
    public Transform spawnPoint;
    public TextMeshProUGUI uiText;

    private int streak = 0;
    private const int GOAL = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            streak++;
            if (streak >= GOAL)
            {
                SceneManager.LoadScene("WinScene");
            }
            else
            {
                ResetPaper("NICE! Streak: " + streak);
            }
        }
    }

    void Update()
    {
        // If paper falls off the bottom of the screen (floor)
        if (paper.position.y < -5f)
        {
            streak = 0; // RESET STREAK
            ResetPaper("MISSED! Try Again.");
        }
    }

    void ResetPaper(string msg)
    {
        uiText.text = msg;
        paper.GetComponent<Rigidbody2D>().simulated = false;
        paper.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        paper.position = spawnPoint.position;
    }
}