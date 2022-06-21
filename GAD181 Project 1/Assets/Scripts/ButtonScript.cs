using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void ActivateTheGraveyard()
    {
        SceneManager.LoadScene("Base Scene");
    }

    public void ImTooScared()
    {
        Application.Quit();
    }

    public void TakeMeHome()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
