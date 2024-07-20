using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCtrl : MonoBehaviour
{

    private void OnEnable()
    {
        EventManager.onDamage += onTakeDmg;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        EventManager.onDamage -= onTakeDmg;
    }

    public void onTakeDmg(GameObject enemy)
    {
        if (enemy == gameObject)
        {
            Debug.Log("I DEAD");
        }
    }

}
