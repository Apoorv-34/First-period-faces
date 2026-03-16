using UnityEngine;
using UnityEngine.SceneManagement;
public class Friendliness : MonoBehaviour
{
    [SerializeField] private float startinghealth;
    public float currentHealth;

    public void Awake()
    {
        currentHealth = startinghealth;
        DontDestroyOnLoad(gameObject);
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, 10);

        if (currentHealth > 0)
        {
            Debug.Log("GameOver");

        }
        else
        {
        }
    }
    public void GiveHealth(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth + _damage, 0, 10);
    }


}
