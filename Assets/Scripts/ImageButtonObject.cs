using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageButtonObject : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    private void OnMouseDown()
    {
        obj.SetActive(true);
    }
}
