using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    private float inputcount;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public string playSceneName = "Day_0";

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            inputcount += 1;
        }
        if (inputcount ==3)
        {
            one.SetActive(false);
            two.SetActive(true);
        }
        if (inputcount ==7)
        {
            two.SetActive(false);
            three.SetActive(true);
        }
        if (inputcount == 11)
        {
            SceneManager.LoadScene(playSceneName);
        }
    }

}
