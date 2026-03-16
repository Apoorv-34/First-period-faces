using UnityEngine;
using System.Collections;

public class PaperThrow : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 startPos;
    Vector2 currentPos;

    public float forceMultiplier = 4f;
    public Transform spawnPoint;
    public float resetDelay = 2f;

    bool hasThrown = false;
    bool canThrow = true;

    GameManager gameManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

        gameManager = FindObjectOfType<GameManager>();
    }

    void OnMouseDown()
    {
        if (!canThrow || hasThrown) return;

        startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseUp()
    {
        if (!canThrow || hasThrown) return;

        currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 force = (startPos - currentPos) * forceMultiplier;

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.AddForce(force, ForceMode2D.Impulse);

        hasThrown = true;
        canThrow = false;

        gameManager.RegisterThrow();

        StartCoroutine(ResetBall());
    }

    IEnumerator ResetBall()
    {
        yield return new WaitForSeconds(resetDelay);

        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        transform.position = spawnPoint.position;

        hasThrown = false;
        canThrow = true;
        DustbinTrigger dustbin = FindObjectOfType<DustbinTrigger>();
        dustbin.ResetTrigger();

    }
}
