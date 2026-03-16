using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;

    [Header("Character Buttons")]
    public Button[] characterButtons;   // 👈 ADD THIS

    [Header("Dialogue Data")]
    [TextArea(2, 4)]
    public string[] dialogues;

    private int currentIndex = 0;
    private bool dialogueActive = false;

    void Start()
    {
        StartDialogue();
    }

    void Update()
    {
        if (!dialogueActive) return;

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            ShowNextDialogue();
        }
    }

    public void StartDialogue()
    {
        if (dialogues.Length == 0)
        {
            Debug.LogWarning("Dialogue array is empty!");
            return;
        }

        currentIndex = 0;
        dialogueActive = true;

        dialogueBox.SetActive(true);
        dialogueText.text = dialogues[currentIndex];

        DisableButtons(); // 👈 LOCK buttons
    }

    void ShowNextDialogue()
    {
        currentIndex++;

        if (currentIndex >= dialogues.Length)
        {
            EndDialogue();
            return;
        }

        dialogueText.text = dialogues[currentIndex];
    }

    void EndDialogue()
    {
        dialogueActive = false;
        dialogueBox.SetActive(false);

        EnableButtons(); // 👈 UNLOCK buttons
    }

    void DisableButtons()
    {
        foreach (Button btn in characterButtons)
        {
            btn.interactable = false;
        }
    }

    void EnableButtons()
    {
        foreach (Button btn in characterButtons)
        {
            btn.interactable = true;
        }
    }
}
