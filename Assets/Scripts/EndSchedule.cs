using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSchedule : MonoBehaviour
{
    [SerializeField] private GameManager gm;

    public void OnTriggerEnter2D(Collider2D other) {
        gm.endGame();
    }
}
