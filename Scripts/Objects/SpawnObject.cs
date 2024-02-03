using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] [Range(0f,1f)] float probability;

    public void Spawn()
    {
        if(Random.value < probability)
        {
            GameObject obj = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
