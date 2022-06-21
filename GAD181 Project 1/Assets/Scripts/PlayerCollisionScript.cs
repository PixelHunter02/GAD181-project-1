using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject zombieCollidedUI;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.name.Contains("Zombie"))
        {
            gameManager.GetComponent<GameManager>().timer = -1;
            zombieCollidedUI.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            zombieCollidedUI.SetActive(false);
        }
    }
}
