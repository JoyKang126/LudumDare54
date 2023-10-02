using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterTick : MonoBehaviour
{
    [SerializeField] private float interval;
    [SerializeField] private Vector3 originPos;
    [SerializeField] private int health;
    private int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = originPos + new Vector3(interval*health, 0,0);
    }
}
