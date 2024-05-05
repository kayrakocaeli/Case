using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float movementSpeed = 2f;
    public Rigidbody2D rb;
    Vector2 movement;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed*Time.fixedDeltaTime);
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
}
