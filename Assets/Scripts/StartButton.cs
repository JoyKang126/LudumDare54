using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("click");
        SceneManager.LoadScene("Intro1");
    }

    public void StartTutorial()
    {
        FindObjectOfType<AudioManager>().Play("click");
        SceneManager.LoadScene("Tutorial");
    }
}
