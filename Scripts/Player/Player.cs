using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP = 100;
    [SerializeField] StatusBar hpBar;

    [HideInInspector] public Level level;

    private void Awake()
    {
        level = GetComponent<Level>();
    }

    private void Start()
    {
        hpBar.SetState(currentHP, maxHP);
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Debug.Log("TEST");
        }
        hpBar.SetState(currentHP, maxHP);
    }

    public void Heal(float amount)
    {
        if (currentHP <= 0) { return; }

        currentHP += amount;

        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        hpBar.SetState(currentHP, maxHP);
    }
}
