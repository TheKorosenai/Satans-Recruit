using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject PauseMenu;
    public bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnPause();
        }
    }

    public void PauseUnPause()
    {
        if (paused)
        {
            paused = false;
            PauseMenu.SetActive(false);
        }
        else
        {
            paused = true;
            PauseMenu.SetActive(true);
        }
    }

}
