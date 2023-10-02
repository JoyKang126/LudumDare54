using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterTick : MonoBehaviour
{
    [SerializeField] private float interval;
    private Vector3 originPos;

    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
    }

    // Update is called once per frame
    public void updateMeter(float health)
    {
        transform.position = originPos + new Vector3(interval*health, 0,0);
    }
}
