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
    public List<Modifier> availableModifiers = new List<Modifier>();
    public Card selectedCard;

    public ModifierManager modifierManager;

    /*
     * START
     * Randomises modifier assignments when the card selection system loads.
     */
    private void Start()
    {
        RandomiseCardModifiers();
    }
    
    /*
     * RANDOMISE CARD MODIFIERS
     * Assigns available modifiers to cards in a random order.
     */
    public void RandomiseCardModifiers()
    {
        List<Modifier> modifierPool = new List<Modifier>(availableModifiers);

        foreach (Card card in availableCards)
        {
            if (card == null)
            {
                continue;
            }
            if (modifierPool.Count == 0)
            {
                return;
            }

            int randomIndex = Random.Range(0, modifierPool.Count);
            card.SetModifier(modifierPool[randomIndex]);

            modifierPool.RemoveAt(randomIndex);
        }
    }

    // Methods

    /*
     * GET SELECTED CARD
     * Returns the currently selected card.
     */
    public Card GetSelectedCard()
    {
        return selectedCard;
    }

    /*
     * SELECT CARD
     * Stores the selected card and applies its modifiers effect.
     */
    public void SelectCard(Card card)
    {
        if(card == null)
        {
            return;
        }

        selectedCard = card;

        if (modifierManager != null && card.modifier != null)
        {
            modifierManager.ApplyModifier(card.modifier);
        }
    }
}