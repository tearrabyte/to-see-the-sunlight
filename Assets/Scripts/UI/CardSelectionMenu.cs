using TMPro;
using UnityEngine;
using System.Collections;

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
    public PlayerMovement playerMovement;

    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI descriptionText;

    private Card pendingCard;
    private bool hasConfirmedCard;

    /*
     * START
     * Initalizes UI elements and disables the players movement while the card selection menu is active
     * */
    private void Start()
    {
        if (descriptionText != null)
        {
            descriptionText.text = "";
        }

        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }    
    }
    
    // Methods
    public void Show()
    {

    }

    /*
     * HIDE MENU
     * Closes the card selection menu and restores the players movements
     */
    public void Hide()
    {
        cardMenuPanel.SetActive(false);

        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }
    }

    public void DisplayCards()
    {

    }

    /*
     * REVEAL ALL CARDS
     * Reveals all cards that are currently hidden/displayed.
     */
    public void RevealCards()
    {
        foreach (Card card in cards)
        {
            card.Reveal();
        }
    }
    /*
     * SELECT CARD
     * Stores the selected card and highlights it visually while reducing the size of the other cards.
     */
    public void SelectCard(Card card)
    {
        if (card != null && hasConfirmedCard == false)
        {
            pendingCard = card;

            foreach (Card currentCard in cards)
            {
                if (currentCard == card)
                {
                    currentCard.transform.localScale = Vector3.one;
                }
                else
                {
                    currentCard.transform.localScale = Vector3.one * 0.80f;
                }
            }
        }
    }
    /*
     * CONFIRM CARD
     * Applies the selected modifier and transitions the menu into the continue state.
     */

    public void ConfirmSelectedCard()
    {
        if (hasConfirmedCard == true)
        {
            Hide();
            return;
        }

        if (cardSystem != null && pendingCard != null)
        {
            StartCoroutine(RevealCardsOneByOne());
            cardSystem.SelectCard(pendingCard);
            UpdateDescription(pendingCard);

            if (buttonText != null)
            {
                buttonText.text = "Continue";
            }
            hasConfirmedCard = true;
        }
    }
    /*
     * SHOW CARD DESCRIPTION
     * Updates the description text when hovering over a card that has been revealed.
     */
    public void ShowCardDescription(Card card)
    {
        if (hasConfirmedCard == true)
        {
            UpdateDescription(card);
        }
    }
    /*
     * UPDATE DESCRIPTION
     * Displays the description associated with the modifier
     */
    private void UpdateDescription(Card card)
    {
        if (descriptionText != null && card != null && card.modifier != null)
        {
            descriptionText.text = card.modifier.description;
        }
    }
    /*
     * CARD REVEAL SEQUENCE
     * Reveals the selected card first, then reveals the remaining cards one by one with a delay.
     */
    private IEnumerator RevealCardsOneByOne()
    {
        pendingCard.Reveal();

        yield return new WaitForSeconds(1.5f);

        foreach (Card card in cards)
        {
            if (card != pendingCard)
            {
                card.Reveal();
                yield return new WaitForSeconds(1.5f);
            }
        }
        UpdateDescription(pendingCard);
    }
}