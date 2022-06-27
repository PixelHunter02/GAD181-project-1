using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreScript : MonoBehaviour
{
    public TextMeshProUGUI highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "High Score: " + GameManager.wins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
