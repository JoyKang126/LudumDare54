using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageButton : MonoBehaviour
{
    [SerializeField] private string nextScene;
    private void OnMouseDown()
    {
        SceneManager.LoadScene(nextScene);
    }
}
