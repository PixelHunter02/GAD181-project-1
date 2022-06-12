using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePickUp : MonoBehaviour
{
    public delegate void CollectiblePickup();
    public static event CollectiblePickup collectiblePickupEvent;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag.Contains("Player") && gameObject.tag.Contains("PickUp"))
        {
            collectiblePickupEvent?.Invoke();
            Destroy(gameObject);
        }
    }
}
