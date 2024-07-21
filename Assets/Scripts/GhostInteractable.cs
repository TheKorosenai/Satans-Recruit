using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostInteractable : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.onGhostInteracted += GhostInteracted;
    }

    private void OnDisable()
    {
        EventManager.onGhostInteracted -= GhostInteracted;
    }

    public void GhostInteracted()
    {
        //shit to do when a ghost interacts

    }
}
