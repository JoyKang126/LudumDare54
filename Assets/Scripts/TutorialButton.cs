using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButton : MonoBehaviour
{
    [SerializeField] private GameObject nextobj;
    [SerializeField] private GameObject prevobj;
    public void NextButton()
    {
        FindObjectOfType<AudioManager>().Play("click");
        gameObject.SetActive(false);
        nextobj.SetActive(true);
    }

    public void PrevButton()
    {
        FindObjectOfType<AudioManager>().Play("click");
        gameObject.SetActive(false);
        prevobj.SetActive(true);
    }

    public void SkipTutorial()
    {
        FindObjectOfType<AudioManager>().Play("click");
        SceneManager.LoadScene("LevelFinal");
    }
}
