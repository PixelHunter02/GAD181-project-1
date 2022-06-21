using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject pauseUI;
    public GameObject camController;
    public GameObject zombie;

    public bool isPaused = false;

    private void Start()
    {
        zombie = GameObject.FindGameObjectWithTag("Zombie");
        pauseUI = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        gameUI.SetActive(false);
        pauseUI.SetActive(true);
        camController.SetActive(false);
        zombie.GetComponent<AudioSource>().enabled = false;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameUI.SetActive(true);
        pauseUI.SetActive(false);
        camController.SetActive(true);
        zombie.GetComponent<AudioSource>().enabled = true;
        Time.timeScale = 1f;
    }

    public void SendToHome()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
