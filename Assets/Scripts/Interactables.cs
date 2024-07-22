using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{

    public List<GameObject> EnemiesAffected = new List<GameObject>();

    private void OnEnable()
    {
        EventManager.onGhostInteracted += Interact;
    }

    private void OnDisable()
    {
        EventManager.onGhostInteracted -= Interact;
    }


    void Interact(GameObject obj)
    {
        if(obj == gameObject && EnemiesAffected.Count > 0)
        {
            EventManager.scareEnemy(EnemiesAffected, transform.Find("PTR").gameObject);
        }
    }


}
