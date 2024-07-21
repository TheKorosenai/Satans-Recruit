using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCtrl : MonoBehaviour
{

    public ghostPlayerCtrl ghost;
    public float timeRemaining;
    public float maxTime = 5f;
    playerSwap isAssEnabled;
    public Image ghostTimer;



    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0 && ghost.enabled==true)
        {
            timeRemaining -= Time.deltaTime;
            ghostTimer.fillAmount = timeRemaining / maxTime;
        }
    }
}
