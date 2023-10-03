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
        FindObjectOfType<AudioManager>().Play("popdefault");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("click");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

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
