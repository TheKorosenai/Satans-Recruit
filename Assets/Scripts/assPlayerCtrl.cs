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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ghost = GameObject.Find("Ghost").GetComponent<ghostPlayerCtrl>();
        enemy = GameObject.Find("Enemy1").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        speedY = Input.GetAxisRaw("Vertical") * moveSpeed;
        rb.velocity = new Vector2(speedX, speedY);
        ghost.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, 0);
        distance = Vector3.Distance(rb.transform.position, enemy.transform.position);

        if (Input.GetKeyDown(KeyCode.Space) && enemyInRange !=null)
        {
            EventManager.takingDamage(enemyInRange);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyInRange = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyInRange = null;
        }
    }



}
