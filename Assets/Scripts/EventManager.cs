using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnPlayerSwitch();
    public static event OnPlayerSwitch onPlayerSwitch;

    public delegate void OnDamage(GameObject enemy);
    public static event OnDamage onDamage;

    public delegate void OnHideChest(GameObject chest);
    public static event OnHideChest onHideChest;

    public delegate void OnLeaveChest();
    public static event OnLeaveChest onLeaveChest;


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

    public static void hideInChest (GameObject chest)
    {
        if (onHideChest != null)
        {
            onHideChest.Invoke(chest);
        }
    }

    public static void leaveOutChest ()
    {
        if (onLeaveChest != null)
        {
            onLeaveChest();
        }
    }
}
