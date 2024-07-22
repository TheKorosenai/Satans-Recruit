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

    public delegate void OnGhostInteracted(GameObject obj);
    public static event OnGhostInteracted onGhostInteracted;

    public delegate void OnEnemyScare(List<GameObject> enemy, GameObject ptr);
    public static event OnEnemyScare onEnemyScare;

    public delegate void OnAssassinVisible();
    public static event OnAssassinVisible onAssassinVisible;

    public delegate void OnPlayerDeath();
    public static event OnPlayerDeath onPlayerDeath;

    public delegate void OnBossKill(GameObject bossObj);
    public static event OnBossKill onBossKill;


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

    public static void ghostInteracted(GameObject obj)
    {
        if (onGhostInteracted != null)
        {
            onGhostInteracted(obj);
        }
    }

    public static void scareEnemy(List<GameObject> enemies, GameObject ptr)
    {
        if (onEnemyScare != null)
        {
            onEnemyScare(enemies, ptr);
        }
    }

    public static void assassinVisible()
    {
        if (onAssassinVisible != null)
        {
            onAssassinVisible();
        }
    }

    public static void PlayerDeath()
    {
        if (onPlayerDeath != null)
        {
            onPlayerDeath();
        }
    }

    public static void BossKill(GameObject bossObj)
    {
        if (onBossKill != null)
        {
            onBossKill(bossObj);
        }
    }
    
}
