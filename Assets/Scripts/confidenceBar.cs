using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class confidenceBar : MonoBehaviour
{

    public Image confBar;
    public float totalConf;
    public List<GameObject> enemies;
    public float ECount;
    public float currentConf;

    private void OnEnable()
    {
        EventManager.onDamage += UpdateConfidence;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        ECount = enemies.Count;
        totalConf = ECount * 100;
    }

    // Update is called once per frame
    void Update()
    {
        confBar.fillAmount = currentConf / totalConf;
    }

    public void UpdateConfidence(GameObject enemy)
    {
        enemies.Remove(enemy);
        currentConf += 90;
    }

    public bool CanKillBoss()
    {
        if(currentConf / totalConf >= 0.7)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
