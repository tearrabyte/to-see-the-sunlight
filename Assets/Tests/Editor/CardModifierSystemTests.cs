using UnityEngine;
using NUnit.Framework;

public class CardModifierSystemTests
{
    [Test]
    public void Select_Card_Stores_Selected_Card()
    {
        GameObject cardObject = new GameObject();
        Card card = cardObject.AddComponent<Card>();

        GameObject systemObject = new GameObject();
        CardSelectionSystem cardSelectionSystem = systemObject.AddComponent<CardSelectionSystem>();
        cardSelectionSystem.SelectCard(card);

        Assert.AreEqual(card, cardSelectionSystem.GetSelectedCard());

        Object.DestroyImmediate(cardObject);
        Object.DestroyImmediate(systemObject);
    }

    [Test]
    public void Selected_Card_Applies_Card_Modifier()
    {
        GameObject cardObject = new GameObject();
        Card card = cardObject.AddComponent<Card>();

        Modifier modifier = new Modifier();
        modifier.type = ModifierType.Environment;
        modifier.description = "Test Modifier";
        card.modifier = modifier;

        GameObject systemObject = new GameObject();
        CardSelectionSystem cardSelectionSystem = systemObject.AddComponent<CardSelectionSystem>();

        ModifierManager modifierManager = systemObject.AddComponent<ModifierManager>();
        cardSelectionSystem.modifierManager = modifierManager;

        cardSelectionSystem.SelectCard(card);

        Assert.Contains(modifier, modifierManager.activeModifiers);

        Object.DestroyImmediate(cardObject);
        Object.DestroyImmediate(systemObject);
    }
}