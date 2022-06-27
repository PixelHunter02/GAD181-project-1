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
            gameManager.GetComponent<GameManager>().timer = 10;
            gameManager.GetComponent<GameManager>().characterController.enabled = false;
            gameManager.GetComponent<GameManager>().player.transform.position = gameManager.GetComponent<GameManager>().playerSpawn.transform.position;
            gameManager.GetComponent<GameManager>().zombie.transform.position = gameManager.GetComponent<GameManager>().zombieSpawn.transform.position;
            gameManager.GetComponent<GameManager>().zombie.GetComponent<AudioSource>().enabled = false;
            gameManager.GetComponent<GameManager>().timerUIGO.SetActive(false);
        Time.timeScale = 0;
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
