using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (Despawnable.IsDespawnable(other.gameObject))
        {
            Destroy(other.gameObject);
        }
    }
}
