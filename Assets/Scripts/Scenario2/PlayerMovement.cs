using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    float movementSpeed = 5f;
    Rigidbody2D rb;
    Animator animator; 

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movement = Vector2.zero;
    }


    private void Update()
    {
        //Handle Input here 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    //Called a fixed amount of times every second.
    void FixedUpdate()
    {
        //Handle Movement here
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime );
    }
}
