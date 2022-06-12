using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public delegate void timerDone();
    public static event timerDone timerDoneEvent;
    public float timer;
    public static bool interacting;
    public TextMeshProUGUI timerUI;
    //public TextMeshProUGUI retry;

    private void Start() 
    {
        timer = 10f;
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
            Time.timeScale = 0;
            //retry.text = "Press E To Try Again";
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1;
            // retry.text = "";
        }
    }
}
