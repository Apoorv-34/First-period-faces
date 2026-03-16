using UnityEngine;

public class DustbinTrigger : MonoBehaviour
{
    GameManager gameManager;
    bool scoredThisThrow = false;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (scoredThisThrow) return;

        if (other.CompareTag("Player"))
        {
            scoredThisThrow = true;

            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            // Stop ball physics
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.bodyType = RigidbodyType2D.Kinematic;

            // Snap ball visually into dustbin
            other.transform.position = transform.position + Vector3.down * 0.3f;

            gameManager.RegisterSuccess();
        }
    }

    // Called automatically when ball is reset
    public void ResetTrigger()
    {
        scoredThisThrow = false;
    }
}
