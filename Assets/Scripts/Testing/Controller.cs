using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Controller : MonoBehaviour
{

    Rigidbody2D rb;
    Camera cam;
    float horizontal, vertical;
    Vector3 velocity;

    public float moveSpeed = 6;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }


    void Update()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
        transform.right = direction;
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized * moveSpeed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(velocity.x, velocity.y) * Time.fixedDeltaTime);
    }

}
