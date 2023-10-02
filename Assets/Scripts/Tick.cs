using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tick : MonoBehaviour
{
    [SerializeField] private float interval = 2;
    [SerializeField] private float tickDistance = -0.5f;
    private Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        InvokeRepeating("ChangePosition", 0, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangePosition() {
        transform.position = spawnPos;
        spawnPos += new Vector3(0, tickDistance , 0);
    }
}
