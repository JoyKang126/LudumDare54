using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float socialmeter;
    [SerializeField] private float academicsmeter;
    [SerializeField] private float happiness;
        
    private float timer = 10;
    //private gameObject heldMem;
    public bool isHolding;

    // Start is called before the first frame update
    void Start()
    {
        socialmeter = 50;
        academicsmeter = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 10;
        }

    }

    private void holdMemory(Memory mem)
    {
        //heldMem = mem;
        //isHolding = true;
    }
}
