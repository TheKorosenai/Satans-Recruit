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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ghost = GameObject.Find("Ghost").GetComponent<ghostPlayerCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        speedY = Input.GetAxisRaw("Vertical") * moveSpeed;
        rb.velocity = new Vector2(speedX, speedY);
        ghost.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, 0);
    }
}
