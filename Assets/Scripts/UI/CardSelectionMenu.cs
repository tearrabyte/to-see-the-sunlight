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
    public Card[] cards;

    public GameObject cardMenuPanel;

    private Card pendingCard;

    // Methods
    public void Show()
    {

    }

    public void Hide()
    {
        cardMenuPanel.SetActive(false);
    }

    public void DisplayCards()
    {

    }

    public void RevealCards()
    {
        foreach (Card card in cards)
        {
            card.Reveal();
        }
    }

    public void SelectCard(Card card)
    {
        if (card != null)
        {
            foreach (Card currentCard in cards)
            {
                currentCard.Deselect();
            }

            pendingCard = card;
            card.Select();
        }
    }

    public void ConfirmSelectedCard()
    {
        if (cardSystem != null && pendingCard != null)
        {
            RevealCards();
            cardSystem.SelectCard(pendingCard);
            Hide();
        }
    }
}