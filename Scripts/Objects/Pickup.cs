using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] int healAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player p = collision.GetComponent<Player>();

        if(p != null)
        {
            p.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
