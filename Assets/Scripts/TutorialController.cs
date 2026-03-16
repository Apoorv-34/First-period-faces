using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TutorialController : MonoBehaviour
{
    public GameObject worldObject;
    public GameObject targetPanel;

    [Header("Correct Option Index")]
    public int correctOptionIndex = 2;

    [Header("Correct Choice Delay")]
    public float correctDelay = 1.5f;

    [Header("Wrong Choice UI")]
    public GameObject wrongChoicePanel;
    public float restartDelay = 2.5f;

    [Header("Scene Settings")]
    public string nextSceneName;

    public void OpenPanel()
    {
        worldObject.SetActive(false);
        targetPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        worldObject.SetActive(true);
        targetPanel.SetActive(false);
    }

    public void SelectOption(int optionIndex)
    {
        if (optionIndex == correctOptionIndex)
        {
            // ✅ DO NOT disable panel
            StartCoroutine(CorrectChoiceRoutine());
        }
        else
        {
            // ❌ Disable panel only for wrong
            targetPanel.SetActive(false);
            StartCoroutine(WrongChoiceRoutine());
        }
    }

    IEnumerator CorrectChoiceRoutine()
    {
        // Panel stays visible here
        yield return new WaitForSeconds(correctDelay);
        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator WrongChoiceRoutine()
    {
        if (wrongChoicePanel != null)
            wrongChoicePanel.SetActive(true);

        yield return new WaitForSeconds(restartDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
