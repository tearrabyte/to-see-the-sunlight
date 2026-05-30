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
        List<Modifier> environmentPool = new List<Modifier>();
        List<Modifier> bonusPool = new List<Modifier>();


        foreach (Modifier modifier in availableModifiers)
        {
            if (modifier == null)
            {
                continue;
            }

            if (modifier.type == ModifierType.Vision)
            {
                environmentPool.Add(modifier);
            }
            else if (modifier.type == ModifierType.Movement || modifier.type == ModifierType.Health)
            {
                bonusPool.Add(modifier);
            }
        }

        List<Modifier> selectedModifiers = new List<Modifier>();

        for (int i = 0; i < 2 && environmentPool.Count > 0; i++)
        {
            int randomIndex = Random.Range(0, environmentPool.Count);
            selectedModifiers.Add(environmentPool[randomIndex]);
            environmentPool.RemoveAt(randomIndex);
        }

        if (bonusPool.Count > 0)
        {
            int randomIndex = Random.Range(0, bonusPool.Count);
            selectedModifiers.Add(bonusPool[randomIndex]);
        }

        for (int i = 0; i < availableCards.Count && i < selectedModifiers.Count; i++)
        {
            if (availableCards[i] != null)
            {
                availableCards[i].SetModifier(selectedModifiers[i]);
            }
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