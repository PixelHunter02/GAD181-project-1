using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{
    public GameObject gameManager;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.name.Contains("Zombie"))
        {
            gameManager.GetComponent<GameManager>().timer = -1;
        }
    }
}
