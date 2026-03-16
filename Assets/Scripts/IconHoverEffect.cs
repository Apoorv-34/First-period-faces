using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class IconHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("References")]
    public GameObject hoverBorder;   // 👈 THIS creates the field

    [Header("Hover Settings")]
    public Vector3 hoverScale = new Vector3(1.1f, 1.1f, 1.1f);

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;

        if (hoverBorder != null)
            hoverBorder.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverBorder != null)
            hoverBorder.SetActive(true);

        transform.localScale = hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoverBorder != null)
            hoverBorder.SetActive(false);

        transform.localScale = originalScale;
    }
}

