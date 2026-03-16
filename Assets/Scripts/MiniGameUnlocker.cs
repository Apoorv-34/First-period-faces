using UnityEngine;
using UnityEngine.UI;

public class MinigameUnlocker : MonoBehaviour
{
    public GameObject minigameButton; // GameObject, not Button

    void Start()
    {
        if (minigameButton != null)
            minigameButton.SetActive(false); // 🔒 hidden at start
    }

    // Call this ONLY when correct option is chosen
    public void UnlockMinigame()
    {
        if (minigameButton != null)
            minigameButton.SetActive(true); // 👀 show button
    }
}
