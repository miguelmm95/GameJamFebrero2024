using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    [HideInInspector]
    public Vector3 movementVector;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;

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

        animate.horizontal = movementVector.x;

        if (movementVector.x != 0)
        {
            lastHorizontalVector = movementVector.x;
        }
        if(movementVector.y != 0)
        {
            lastVerticalVector = movementVector.y;
        }

        movementVector *= speed;

        rb2d.velocity = movementVector;
    }
}
