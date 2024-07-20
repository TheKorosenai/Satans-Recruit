using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnPlayerSwitch();
    public static event OnPlayerSwitch onPlayerSwitch;

    public delegate void OnDamage(GameObject enemy);
    public static event OnDamage onDamage;

    public static void PlayerSwitch()
    {
        if (onPlayerSwitch != null)
        {
            onPlayerSwitch();

        }
    }


    public static void takingDamage(GameObject enemy)
    {
        if (onDamage != null)
        {
            onDamage.Invoke(enemy);
        }

    }
}
