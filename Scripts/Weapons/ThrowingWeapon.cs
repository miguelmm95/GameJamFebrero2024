using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack;
    float timer;

    PlayerMovement playerMovement;

    [SerializeField] GameObject knifePrefab;

    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void Update()
    {
        if(timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        SpawnKnife();
    }

    private void SpawnKnife()
    {
        GameObject throwingKnife = Instantiate(knifePrefab);
        throwingKnife.transform.position = transform.position;
        throwingKnife.GetComponent<ThrowingKnifeProjectile>().SetDirection(playerMovement.lastHorizontalVector, 0f);
    }
}
