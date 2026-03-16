using UnityEngine;
using UnityEngine.UI;

public class SingleChoiceLock : MonoBehaviour
{
    public Button[] optionButtons;

    private bool locked = false;

    void Start()
    {
        foreach (Button btn in optionButtons)
        {
            btn.onClick.AddListener(LockChoices);
        }
    }

    void LockChoices()
    {
        if (locked) return;

        locked = true;

        foreach (Button btn in optionButtons)
        {
            btn.interactable = false;
        }
    }
}
