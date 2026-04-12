using UnityEngine;

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
