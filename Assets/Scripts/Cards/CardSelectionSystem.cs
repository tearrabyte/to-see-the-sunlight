using System.Collections.Generic;
using UnityEngine;

/*
 * CardSelectionSystem
 * -------------------
 * Handles logic for presenting and selecting cards.
 */

public class CardSelectionSystem : MonoBehaviour
{
    // Variables
    public List<Card> availableCards = new List<Card>();
    public Card selectedCard;

    public ModifierManager modifierManager;

    // Methods
    public Card GetSelectedCard()
    {
        return selectedCard;
    }

    public void SelectCard(Card card)
    {
        if(card == null)
        {
            return;
        }

        selectedCard = card;

        if (modifierManager != null && card.modifier != null)
        {
            {
                modifierManager.ApplyModifier(card.modifier);
            }
        }
    }
}
