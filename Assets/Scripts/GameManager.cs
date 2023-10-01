using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float socialmeter;
    [SerializeField] private float academicsmeter;
    [SerializeField] private float happiness;
    [SerializeField] private LevelInfo levelInfo;
    [SerializeField] private SnapController snapControl;
    [SerializeField] public List<MemoryBlock> queueSpaces;
    [SerializeField] public List<MemoryBlock> memSpaces;
    //[SerializeField] public TMP_Text statusField;
    
    private float timer = 7;
    //private gameObject heldMem;
    public bool isHolding;
    public GameObject memPrefab;


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
            Debug.Log(timer);
        }
        else
        {
            //spawn new memory
            MemoryInfo nextmem = levelInfo.getNextMemory();
            if (nextmem != null)
            {
                //find first available queue space
                Vector3 pos = new Vector3(0,0,0);
                MemoryBlock selected = null;
                foreach (MemoryBlock queue in queueSpaces)
                {
                    if (!queue.isOccupied)
                    {
                        pos = queue.transform.position;
                        queue.isOccupied = true;
                        selected = queue;
                        break;
                    }
                        
                }
                if (selected != null)
                {
                    //create a new memory block at the spot found above
                    GameObject mem = Instantiate (memPrefab, pos, Quaternion.identity);
                    mem.GetComponent<Memory>().snappedTo = selected;
                    selected.heldMem = mem.GetComponent<Memory>();
                    mem.GetComponent<Memory>().memID = nextmem.memID;
                    mem.GetComponent<Memory>().memDesc = nextmem.memDescription;
                    mem.SetActive(true);
                    snapControl.addDraggable(mem.GetComponent<Memory>());
                }
                else
                {
                    //queue is full
                    //trigger end game state
                }
                
            }
            
            timer = 7;
        }

    }

    public void updateSocials(float change)
    {
        socialmeter += change;
    }

    public void updateAcademics(float change)
    {
        academicsmeter += change;
    }

    // public void updateStatusField(string content)
    // {
    //     statusField.text = content;
    // }
}
