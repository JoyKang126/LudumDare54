using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tick : MonoBehaviour
{
    public float interval = 2;
    private Vector3 startingPos = new Vector3(-4.863126f, 4.435083f, 0f);
    private Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = startingPos + new Vector3(0, -1, 0);
        InvokeRepeating("ChangePosition", 0, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangePosition() {
        transform.position = spawnPos;
        spawnPos += new Vector3(0, -1, 0);
    }
}
