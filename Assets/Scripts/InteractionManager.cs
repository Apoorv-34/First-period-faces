using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractionManager : MonoBehaviour
{
    public int interactionsNeeded = 3;
    private int currentInteractions = 0;

    [SerializeField] private Button nextSceneButton; // Drag your 'Next' button here in Inspector
    [SerializeField] private string nextSceneName;   // Type the name of your next scene

    void Start()
    {
        // Hide or disable the next scene button at the start
        if (nextSceneButton != null)
            nextSceneButton.gameObject.SetActive(false);
    }

    public void ButtonClicked()
    {
        currentInteractions++;

        if (currentInteractions >= interactionsNeeded)
        {
            ShowNextButton();
        }
    }

    private void ShowNextButton()
    {
        if (nextSceneButton != null)
            nextSceneButton.gameObject.SetActive(true);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}