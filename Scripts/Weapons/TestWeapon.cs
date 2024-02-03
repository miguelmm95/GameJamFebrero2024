using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack = 4f;
    float timer;

    [SerializeField] GameObject leftAttackObject;
    [SerializeField] GameObject rightAttackObject;

    PlayerMovement playerMovement;
    [SerializeField] Vector2 attackSize = new Vector2(4f, 2f);

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        timer = timeToAttack;

        if(playerMovement.lastHorizontalVector > 0)
        {
            rightAttackObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftAttackObject.transform.position, attackSize, 0f);
            ApplyDamage(colliders);
        }
        else
        {
            leftAttackObject.SetActive(true);
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for(int i = 0; i < colliders.Length; i++)
        {
            Debug.Log(colliders[i].gameObject.name);
        }
    }
}
