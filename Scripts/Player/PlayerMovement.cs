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
    public float lastHorizontalDeCoupleVector;
    [HideInInspector]
    public float lastVerticalDeCoupledVector;

    [HideInInspector]
    public float lastHorizontalCoupleVector;
    [HideInInspector]
    public float lastVerticalCoupledVector;

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
        lastHorizontalDeCoupleVector = -1f;
        lastVerticalDeCoupledVector = 1f;

        lastVerticalCoupledVector = -1f;
        lastVerticalCoupledVector = 1f;
    }

    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");


        if(movementVector.x != 0 || movementVector.y != 0)
        {
            lastHorizontalCoupleVector = movementVector.x;
            lastVerticalCoupledVector = movementVector.y;
        }
        

        if (movementVector.x != 0)
        {
            lastHorizontalDeCoupleVector = movementVector.x;
        }
        if(movementVector.y != 0)
        {
            lastVerticalDeCoupledVector = movementVector.y;
        }

        animate.horizontal = movementVector.x;

        movementVector *= speed;

        rb2d.velocity = movementVector;
    }
}
