using UnityEngine;
using UnityEngine.UI;

public class OptionSelector : MonoBehaviour
{
    [Header("Dialogs")]
    public GameObject correctDialog;
    public GameObject wrongDialog;
    public GameObject wrong2;

    [Header("Buttons")]
    public Button[] optionButtons;

    [Header("Character Images")]
    public Image characterImage;
    public Sprite neutralSprite;
    public Sprite happySprite;
    public Sprite sadSprite;

    private bool hasAnswered = false;

    void Start()
    {
        hasAnswered = false;

        correctDialog.SetActive(false);
        wrongDialog.SetActive(false);
        if (wrong2 != null) wrong2.SetActive(false);

        characterImage.sprite = neutralSprite;
    }

    public void CorrectOption(Button clickedButton)
    {
        if (hasAnswered) return;

        hasAnswered = true;
        characterImage.sprite = happySprite;

        correctDialog.SetActive(true);
        wrongDialog.SetActive(false);
        if (wrong2 != null) wrong2.SetActive(false);

        DisableAllButtons();
    }

    public void WrongOption(Button clickedButton)
    {
        if (hasAnswered) return;

        hasAnswered = true;
        characterImage.sprite = sadSprite;

        wrongDialog.SetActive(true);
        correctDialog.SetActive(false);
        if (wrong2 != null) wrong2.SetActive(false);

        DisableAllButtons();
    }

    public void WrongOption2(Button clickedButton)
    {
        if (hasAnswered) return;

        hasAnswered = true;
        characterImage.sprite = sadSprite;

        wrong2.SetActive(true);
        correctDialog.SetActive(false);
        wrongDialog.SetActive(false);

        DisableAllButtons();
    }

    void DisableAllButtons()
    {
        foreach (Button btn in optionButtons)
        {
            btn.interactable = false;
        }
    }
}
