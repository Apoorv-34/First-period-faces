using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneLoader : MonoBehaviour
{
    public string nextSceneName;

    void Start()
    {
        VideoPlayer vp = GetComponent<VideoPlayer>();
        vp.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
