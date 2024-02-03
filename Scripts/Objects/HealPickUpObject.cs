using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickUpObject : MonoBehaviour, IPickupObject
{
    [SerializeField] float healAmount;

    public void OnPickUp(Player player)
    {
        player.Heal(healAmount);
    }
}
