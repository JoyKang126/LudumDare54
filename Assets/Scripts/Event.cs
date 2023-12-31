using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[System.Serializable] public struct Outcome {
    public int value;
    public string statusString;
}
public class Event : MonoBehaviour
{
    [SerializeField] private List<string> requirements = new List<string>();
    [SerializeField] private GameManager gm;
    [SerializeField] private TMP_Text eventName;
    [SerializeField] private bool isHappiness;
    [SerializeField] private bool isAcademics;

    // order the status update strings from lowest to highest
    [SerializeField] private List<Outcome> outcomes = new List<Outcome>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "tick")
        {
            int found = 0;  // index of outcome we'll use
            int num_req = requirements.Count;
            Debug.Log("# reqs: " + num_req);
            foreach (MemoryBlock mb in gm.memSpaces)
            {
                if (mb.isOccupied)
                {
                    Memory mem = mb.heldMem;
                    Debug.Log("event memID: " + mem.memID + " event memDesc: " + mem.memDesc);
                    string mem_id = mem.memID;
                    foreach (string req in this.requirements) {
                        if (req == mem_id) {
                            found++;
                            break;
                        }
                    }
                }
                if (found == num_req) {
                    break;
                }  
            }
            foreach (Memory mem in gm.snapControl.draggableObjects)
            {
                string mem_id = mem.memID;
                foreach (string req in this.requirements) {
                    if (req == mem_id) {
                        mem.transform.GetChild(2).gameObject.SetActive(true);
                        break;
                    }
                }
            }
            Outcome oc = outcomes[found];
            int deltaScore = oc.value;
            string statusUpdateString = oc.statusString;
            Debug.Log("outcome: " + deltaScore + ' ' + statusUpdateString);

            // wait for marker to pass the tick, then grey out the event + update fields
            yield return new WaitForSeconds(0);
            //yield return;
            eventName.color = new Color(1, 1, 1, 0.5f);

            // set portrait and go back to neutral
            if (found == num_req) {
                // pass
                gm.portrait.setHappy();
            }
            else if (found == 0) {
                // fail
                gm.portrait.setSad();
            }
            gm.updateStatusField(statusUpdateString);
            FindObjectOfType<AudioManager>().Play("memory");
            

            // set meters and status
            if (isHappiness) {
                gm.updateHappiness(deltaScore);
            }
            if (isAcademics) {
                gm.updateAcademics(deltaScore);
            }
            yield return new WaitForSeconds(3);
            //yield return;
            gm.portrait.setNeutral();
            
        }
    }
}
