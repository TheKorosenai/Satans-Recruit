using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ghostPlayerCtrl : MonoBehaviour { 

    public float moveSpeed;
    public float speedX, speedY;
    public Rigidbody2D rb;

    public GameObject CurrentObjectInRange;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CurrentObjectInRange = null;
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        speedY = Input.GetAxisRaw("Vertical") * moveSpeed;
        rb.velocity = new Vector2(speedX, speedY);

        if (Input.GetKeyDown(KeyCode.E) && CurrentObjectInRange != null)
        {
            EventManager.ghostInteracted(CurrentObjectInRange);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("InteractRange"))
        {
            CurrentObjectInRange = collision.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InteractRange"))
        {
            CurrentObjectInRange = null;
        }
    }

}
