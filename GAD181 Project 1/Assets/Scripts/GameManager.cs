using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public delegate void timerDone();
    public static event timerDone timerDoneEvent;
    public float timer;
    public static bool interacting;
    public TextMeshProUGUI timerUI;
    public GameObject[] spawn;
    public float x;
    public float y;
    public float z;
    public GameObject win;
    public int random;
    public CharacterController characterController;
    public GameObject player;
    //public TextMeshProUGUI retry;

    private void OnEnable() 
    {
        CollectiblePickUp.collectiblePickupEvent += Win;    

    }

    private void OnDisable() 
    {
        CollectiblePickUp.collectiblePickupEvent -= Win;    
    }
    private void Start() 
    {
        timer = 10f;
        random = Random.Range(0,6);

        Instantiate(win, spawn[random].gameObject.transform.position, Quaternion.identity);
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 0 && interacting != true)
        {
            timer -= Time.deltaTime;
            timerUI.text = "Time Until Reset: " + timer.ToString("F2");
        }

        if(timer <= 0)
        {
            timerDoneEvent?.Invoke();
            timer = 10;
            characterController.enabled = false;
            player.transform.position = new Vector3(14.78125f, 3.814697e-06f, 33f);
            Time.timeScale = 0;
            //retry.text = "Press E To Try Again";
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            characterController.enabled = true;
            Time.timeScale = 1;
            // retry.text = "";
        }
    }
    void Win()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("GameOver");
    }
}
