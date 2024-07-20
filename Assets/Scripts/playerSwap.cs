using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class playerSwap : MonoBehaviour
{ 
    public ghostPlayerCtrl ghost;
    public assPlayerCtrl assassin;
    public bool assActive = true;

    public CinemachineVirtualCamera camTrack;

    private void OnEnable()
    {
        EventManager.onPlayerSwitch += playerSwitch;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //playerSwitch();
            EventManager.PlayerSwitch();
        }

    }

    private void OnDisable()
    {
        EventManager.onPlayerSwitch -= playerSwitch;
    }

    public void playerSwitch()
    {
        if (assActive)
        {
            camTrack.Follow = ghost.transform;
            camTrack.LookAt = ghost.transform;
            assassin.enabled = false;
            ghost.enabled = true;
            assActive = false;
            assassin.rb.velocity = Vector3.zero;

        }
        else
        {
            camTrack.Follow = assassin.transform;
            camTrack.LookAt = assassin.transform;
            assassin.enabled = true;
            ghost.enabled = false;
            assActive = true;
            ghost.rb.velocity = Vector3.zero;
        }
    }
}
