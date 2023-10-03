using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] GameObject endMenu;

    public void BackToStart()
    {
        FindObjectOfType<AudioManager>().Play("click");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }

    public void GoToTutorial() {
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("click");
        SceneManager.LoadScene("Tutorial");
    }

    public void RestartLevel() {
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("click");
        SceneManager.LoadScene("LevelFinal");
    }
}
