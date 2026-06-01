using UnityEngine;
using UnityEngine.UI;

/*
 * Card
 * ----
 * Represents a selectable card that corresponds to a modifier.
 * Cards are selected and revealed to apply their respective effects.
 */

public class Card : MonoBehaviour
{
    /*
     * REFERENCES
     * Stores the card modifier data and visual card references
     */
    public Modifier modifier;
    public bool isRevealed;
    public bool isSelected;
    public GameObject cardBack;
    public GameObject cardFront;
    public Image modifierIcon;
    private Vector3 originalScale;
    
    /*
     * START
     * Initialises the card state and stores its original scale.
     */

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

        if (modifierIcon != null)
        {
            modifierIcon.gameObject.SetActive(false);
        }
    }

    /*
     * SET MODIFIER
     * Assigns a modifier and updates the card icon.
     */
    public void SetModifier(Modifier newModifier)
    {
        modifier = newModifier;

        if (modifierIcon != null && modifier != null)
        {
            modifierIcon.sprite = modifier.icon;
            modifierIcon.gameObject.SetActive(false);
        }

    }

    // Methods

    /*
     * REVEAL
     * Displays the front of the card and hides the back of the card.
     */
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

        if (modifierIcon != null)
        {
            modifierIcon.gameObject.SetActive(true);
        }    
    }

    /*
     * HIDE
     * Displays the back of the cards and hides the front of the cards.
     */
    public void Hide()
    {
        isRevealed = false;

        if (cardBack != null)
        {
            cardBack.SetActive(true);
        }

        if (cardFront != null)
        {
            cardFront.SetActive(false);
        }

        if (modifierIcon != null)
        {
            modifierIcon.gameObject.SetActive(false);
        }
    }    

    /*
     * SELECT
     * Marks the card as selected and makes it larger visually.
     */
    public void Select()
    {
        isSelected = true;
        transform.localScale = originalScale * 1.15f;
    }

    /*
     * DESELECT
     * Restores the card to its original appearance.
     */
    public void Deselect()
    {
        isSelected = false;
        transform.localScale = originalScale;
    }
}