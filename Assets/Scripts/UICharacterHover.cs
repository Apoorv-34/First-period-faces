using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UICharacterHover : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public Image iconImage;          // assign manually
    public Sprite normalSprite;
    public Sprite hoverSprite;

    void Start()
    {
        iconImage.sprite = normalSprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("HOVER ENTER");
        iconImage.sprite = hoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("HOVER EXIT");
        iconImage.sprite = normalSprite;
    }
}
