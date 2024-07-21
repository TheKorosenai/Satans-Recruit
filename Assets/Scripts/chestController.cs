using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestController : MonoBehaviour
{

    public GameObject assassin;
    public GameObject ghost;
    public bool inChest = false;
    private void OnEnable()
    {
        EventManager.onHideChest += onHideChest;
        EventManager.onLeaveChest += onLeaveChest;
    }

    private void OnDisable()
    {
        EventManager.onHideChest -= onHideChest;
        EventManager.onLeaveChest -= onLeaveChest;
    }
    // Start is called before the first frame update
    void Start()
    {
        assassin = GameObject.Find("Assassin");
        ghost = GameObject.Find("Ghost");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inChest == true)
        {
            EventManager.leaveOutChest();
        }
    }

    public void onHideChest(GameObject chest)
    {
        if (chest == gameObject)
        {
            assassin.SetActive(false);
            ghost.SetActive(false);
            inChest = true;
        }
    }
    public void onLeaveChest()
    {
        assassin.SetActive(true);
        ghost.SetActive(true);
        inChest = false;
    }
}

