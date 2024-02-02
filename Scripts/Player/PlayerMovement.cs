using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector3 movementVector;
    bool facingRight = true;

    AnimateController animate;

    [SerializeField] float speed = 3f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
        animate = GetComponent<AnimateController>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        animate.horizontal = Input.GetAxisRaw("Horizontal");

        if(animate.horizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if(animate.horizontal < 0 && facingRight)
        {
            Flip();
        }

        movementVector *= speed;

        rb2d.velocity = movementVector;
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
