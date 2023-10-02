using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("escape pressed");
            if (pauseMenu.activeSelf) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }

    public void GoToTutorial() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Tutorial");
    }
}
