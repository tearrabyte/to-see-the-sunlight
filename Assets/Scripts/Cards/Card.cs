using UnityEngine;

/*
 * Card
 * ----
 * Represents a selectable card that corresponds to a modifier.
 * Cards are selected and revealed to apply their respective effects.
 */

public class Card : MonoBehaviour
{
    // Variables
    public Modifier modifier;
    public bool isRevealed;
    public bool isSelected;
    public GameObject cardBack;
    public GameObject cardFront;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;

        if (cardBack != null)
        {
            cardBack.SetActive(true);
        }

        if (cardFront != null)
        {
            cardFront.SetActive(false);
        }
    }

    // Methods
    public void Reveal()
    {
        isRevealed = true;

        if (cardBack != null)
        {
            cardBack.SetActive(false);
        }

        if (cardFront != null)
        {
            cardFront.SetActive(true);
        }
    }

    public void Select()
    {
        isSelected = true;
        transform.localScale = originalScale * 1.15f;
    }

    public void Deselect()
    {
        isSelected = false;
        transform.localScale = originalScale;
    }
}