using System;
using UnityEngine;

/*
 * ICE CAVE MECHANIC
 * Biome specific mechanic for the ice cave level
 * Listens for card selection to finish then activates
 * the cold meter when the biome is active
 */
public class IceCaveMechanic : BiomeMechanic
{

    [SerializeField] private ColdMeter coldMeter;
    [SerializeField] private CardSelectionMenu cardSelectionMenu;

    /*
     * START
     * Attaches to the card selection closed event
     */
    private void Start()
    {
        if (cardSelectionMenu != null)
        {
            cardSelectionMenu.onMenuClosed += HandleMenuClosed;
        }
            
    }

    /*
     * ON DESTROY
     * Unsigns from the event
     */
    private void OnDestroy()
    {
        if (cardSelectionMenu != null)
        {
            cardSelectionMenu.onMenuClosed -= HandleMenuClosed;
        }
            
    }

    /*
     * HANDLE MENU CLOSED
     * Only activates cold meter if this biome is currently active
     */
    private void HandleMenuClosed()
    {
        if (isActive)
            coldMeter.Activate();
    }
}