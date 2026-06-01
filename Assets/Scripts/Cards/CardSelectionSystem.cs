using System.Collections.Generic;
using UnityEngine;

/*
 * CardSelectionSystem
 * -------------------
 * Handles logic for presenting and selecting cards.
 */

public class CardSelectionSystem : MonoBehaviour
{
    /*
     * REFERENCES
     * Stores available cards, level specific modifiers and selected card data.
     */
    public List<Card> availableCards = new List<Card>();

    public List<Modifier> levelOneEnvironmentModifiers = new List<Modifier>();
    public List<Modifier> levelTwoEnvironmentModifiers = new List<Modifier>();
    public List<Modifier> bonusModifiers = new List<Modifier>();

    public Card selectedCard;
    public ModifierManager modifierManager;

    private int currentLevel = 1;
    private List<string> usedBonusModifierDescriptions = new List<string>();

    /*
     * START
     * Randomises modifier assignments when the card selection system loads.
     */
    private void Start()
    {
        RandomiseCardModifiers();
    }

    /*
     * SET CURRENT LEVEL
     * Updates which enviornment modifier pool should be used.
     */
    public void SetCurrentLevel(int level)
    {
        currentLevel = level;
    }

    /*
     * RANDOMISE CARD MODIFIERS
     * Assigns available modifiers to cards in a random order.
     */
    public void RandomiseCardModifiers()
    {
        List<Modifier> environmentPool;

        if (currentLevel == 1)
        {
            environmentPool = new List<Modifier>(levelOneEnvironmentModifiers);
        }
        else
        {
            environmentPool = new List<Modifier>(levelTwoEnvironmentModifiers);
        }


        List<Modifier> bonusPool = new List<Modifier>(); ;

        foreach (Modifier modifier in bonusModifiers)
        {
            if (!usedBonusModifierDescriptions.Contains(modifier.description))
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
            if (modifierManager.GetActiveModifiers().Contains(card.modifier))
            {
                return;
            }
            modifierManager.ApplyModifier(card.modifier);

            if (card.modifier.type == ModifierType.Movement || card.modifier.type == ModifierType.Health)
            {
                if (!usedBonusModifierDescriptions.Contains(card.modifier.description))
                {
                    usedBonusModifierDescriptions.Add(card.modifier.description);
                }
            }
        }
    }
}