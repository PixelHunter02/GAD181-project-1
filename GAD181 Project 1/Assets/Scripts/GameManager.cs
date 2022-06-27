using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Events
    public delegate void timerDone();
    public static event timerDone timerDoneEvent;
    #endregion
    
    #region Floats
    public float timer;
    #endregion

    #region Bools
    public static bool interacting;
    #endregion

    #region UI
    public TextMeshProUGUI timerUI;
    #endregion
    
    #region GameObjects
    public GameObject aStar;
    public GameObject[] maps;
    public GameObject[] spawn;
    public GameObject zombieSpawn;
    public GameObject playerSpawn;
    public GameObject win;
    public GameObject player;
    public GameObject zombie;
    public GameObject timerHitsZeroUI;
    public GameObject timerUIGO;
    #endregion

    #region int
    public int random;
    public static int wins;
    #endregion
    
    #region CharacterControllers
    public CharacterController characterController;
    #endregion

    private void OnEnable() 
    {
        CollectiblePickUp.collectiblePickupEvent += Win;    
        timerDoneEvent += OnTimerOver;
    }

    private void OnDisable() 
    {
        CollectiblePickUp.collectiblePickupEvent -= Win;
        timerDoneEvent -= OnTimerOver;    
    }

    private void Start() 
    {
        Instantiate(maps[Random.Range(0,maps.Length)]);

        aStar.SetActive(true);

        zombieSpawn = GameObject.FindGameObjectWithTag("ZombieSpawn");
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn");

        player = GameObject.FindGameObjectWithTag("Player");
        zombie = GameObject.FindGameObjectWithTag("Zombie");

        player.transform.position = playerSpawn.transform.position;
        zombie.transform.position = zombieSpawn.transform.position;
        
        timer = 10f;
        
        spawn = GameObject.FindGameObjectsWithTag("Spawn");
        
        random = Random.Range(0,spawn.Length);
        
        Instantiate(win, spawn[random].gameObject.transform.position, Quaternion.identity);
        
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
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
            timerHitsZeroUI.SetActive(true);
            //retry.text = "Press E To Try Again";
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            characterController.enabled = true;
            zombie.GetComponent<AudioSource>().enabled = true;
            Time.timeScale = 1;
            timerHitsZeroUI.SetActive(false);
            // retry.text = "";
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            characterController.enabled = true;
            zombie.GetComponent<AudioSource>().enabled = true;
            Time.timeScale = 1;
            timerUIGO.SetActive(true);
            // retry.text = "";
        }
    }

    void OnTimerOver()
    {
        timer = 10;
        characterController.enabled = false;
        player.transform.position = playerSpawn.transform.position;
        zombie.transform.position = zombieSpawn.transform.position;
        zombie.GetComponent<AudioSource>().enabled = false;
        timerUIGO.SetActive(false);
        Time.timeScale = 0;
        wins = 0;
    }

    void Win()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("WinScene");
        wins += 1;
    }
}
