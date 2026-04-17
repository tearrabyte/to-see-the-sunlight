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

    // Methods
    public void Reveal()
    {
        isRevealed = true;
    }

    public void Select()
    {

    }
}
