using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    Transform targetDestination;
    GameObject targetGameObject;
    Player targetPlayer;
    [SerializeField] float speed;

    Rigidbody2D rb2d;

    [SerializeField] float hp;
    [SerializeField] float baseDamage;
    [SerializeField] int experience_reward = 100;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rb2d.velocity = direction * speed;
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if(targetPlayer == null)
        {
            targetPlayer = targetGameObject.GetComponent<Player>();
        }

        targetPlayer.TakeDamage(baseDamage);
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            targetGameObject.GetComponent<Level>().AddExperience(experience_reward);
            GetComponent<DropOnDestroy>().CheckDrop();
            Destroy(gameObject);
        }
    }

    public void OnParticleCollision(GameObject other)
    {
        TakeDamage(10);
    }
}
