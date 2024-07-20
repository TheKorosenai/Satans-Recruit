using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnPlayerSwitch();
    public static event OnPlayerSwitch onPlayerSwitch;


    public static void PlayerSwitch()
    {
        if(onPlayerSwitch != null)
        {
            onPlayerSwitch();
        }
    }

}
