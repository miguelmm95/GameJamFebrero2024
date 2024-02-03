using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player p = collision.GetComponent<Player>();

        if(p != null)
        {
            GetComponent<IPickupObject>().OnPickUp(p);
            Destroy(gameObject);
        }
    }
}
