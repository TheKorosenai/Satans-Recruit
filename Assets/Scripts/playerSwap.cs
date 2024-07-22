using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class playerSwap : MonoBehaviour
{ 
    public ghostPlayerCtrl ghost;
    public assPlayerCtrl assassin;
    public bool assActive = true;
    TimerCtrl timeRem;

    public GameObject ghostView;

    public CinemachineVirtualCamera camTrack;

    private void OnEnable()
    {
        EventManager.onPlayerSwitch += playerSwitch;
    }

    private void Start()
    {
        timeRem = GetComponent<TimerCtrl>();
        ghostView.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            EventManager.PlayerSwitch();
        }
        if (timeRem.timeRemaining <= 0)
        {
            EventManager.PlayerSwitch();
        }

    }

    private void OnDisable()
    {
        EventManager.onPlayerSwitch -= playerSwitch;
    }

    public void playerSwitch()
    {
        if (assActive && timeRem.timeRemaining > 0)
        {
            camTrack.Follow = ghost.transform;
            camTrack.LookAt = ghost.transform;
            assassin.enabled = false;
            ghost.enabled = true;
            assActive = false;
            assassin.rb.velocity = Vector3.zero;
            ghostView.SetActive(true);
        }
        else
        {
            camTrack.Follow = assassin.transform;
            camTrack.LookAt = assassin.transform;
            assassin.enabled = true;
            ghost.enabled = false;
            assActive = true;
            ghost.rb.velocity = Vector3.zero;
            ghostView.SetActive(false);
        }
    }
}
