using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assPlayerCtrl : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed;
    public float speedX, speedY;
    public Rigidbody2D rb;
    ghostPlayerCtrl ghost;
    public bool isEnemyKilled;
    public Rigidbody2D enemy;
    public float distance;

    public GameObject enemyInRange;
    public GameObject chestInRange;

    public bool playerDead = false;

    public GameObject ghostView;


    // implemenet chesh functionality

    private void OnEnable()
    {
        EventManager.onAssassinVisible += Die;
    }

    private void OnDisable()
    {
        EventManager.onAssassinVisible -= Die;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ghost = transform.GetChild(0).GetComponent<ghostPlayerCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerDead)
        {
            speedX = Input.GetAxisRaw("Horizontal") * moveSpeed;
            speedY = Input.GetAxisRaw("Vertical") * moveSpeed;
            rb.velocity = new Vector2(speedX, speedY);
            ghost.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, 0);

            if (Input.GetKeyDown(KeyCode.Space) && enemyInRange != null)
            {
                EventManager.takingDamage(enemyInRange);
            }
            if (Input.GetKeyDown(KeyCode.E) && chestInRange != null) // also here check functionality
            {
                EventManager.hideInChest(chestInRange);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            ghostView.SetActive(true);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyInRange = collision.gameObject;
        }
        if (collision.CompareTag("Chest"))
        {
            chestInRange = collision.gameObject;
        }
        if (collision.CompareTag("Boss"))
        {
            if (gameObject.GetComponent<confidenceBar>().CanKillBoss())
            {
                EventManager.BossKill(collision.gameObject);
            }
            else
            {
                // boss kills player
                Die();
                EventManager.PlayerDeath();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyInRange = null;
        }
        if (collision.CompareTag("Chest"))
        {
            chestInRange = null;
        }
    }

    public void Die()
    {
        // do something that shows I die
        Debug.Log("Player Died");
        EventManager.PlayerDeath();
        playerDead = true;
    }


}
