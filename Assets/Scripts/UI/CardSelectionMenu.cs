using UnityEngine;

/*
 * CardSelectionMenu
 * -----------
 * Displays three hidden modifier cards during gameplay.
 * Handles player interaction for selecting and revealing cards.
 */

public class CardSelectionMenu : MonoBehaviour
{
    // Variables
    public CardSelectionSystem cardSystem;

    // Methods
    public void Show()
    {

    }

    public void Hide()
    {

    }

    public void DisplayCards()
    {

    }

    public void RevealCards()
    {

    }

    public void SelectCard(Card card)
    {
        if(cardSystem != null && card != null)
        {
            cardSystem.SelectCard(card);
        }
    }
}
