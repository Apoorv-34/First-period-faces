using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource clickSound;

    public void PlayClickSound()
    {
        clickSound.Play();
    }
}
