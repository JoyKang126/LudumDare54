using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] private SnapController sc;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
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
        foreach (Memory mem in sc.draggableObjects)
        {
            if (mem.isDragged)
            {
                mem.recoverAfterPause();
                break;
            }
        }
    }

    public void BackToStart()
    {
        FindObjectOfType<AudioManager>().Play("click");
        FindObjectOfType<AudioManager>().StopPlay("bgm");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }

    public void GoToTutorial() {
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("click");
        FindObjectOfType<AudioManager>().StopPlay("bgm");
        SceneManager.LoadScene("Tutorial");
    }

    public void RestartLevel() {
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("click");
        SceneManager.LoadScene("LevelFinal");
    }
}
