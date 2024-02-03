using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPickUpObject : MonoBehaviour, IPickupObject
{
    [SerializeField] int expAmount;

    public void OnPickUp(Player player)
    {
        player.level.AddExperience(expAmount);
    }
}
