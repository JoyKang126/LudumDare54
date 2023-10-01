using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Event : MonoBehaviour
{
    [SerializeField] private List<string> requirements = new List<string>();
    [SerializeField] private GameManager gm;
    [SerializeField] private TMP_Text eventName;
    [SerializeField] private List<MemoryBlock> memSpaces;
    private float deltaSocial = 0f;
    private float deltaAcademics = 0f;
    private string statusUpdateString = "";
    private string mem_id = "";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Trigger");
        
        MemoryBlock selected = null;
        bool found = false;
        foreach (MemoryBlock mb in memSpaces)
        {
            if (mb.isOccupied)
            {
                Memory mem = mb.heldMem;
                Debug.Log("event mem:" + mem);
                string mem_id = mem.memID;
                if (this.mem_id == mem_id) {
                    // update stats positively
                    found = true;
                    gm.updateSocials(deltaSocial);
                    gm.updateAcademics(deltaAcademics);
                    gm.updateStatusField(statusUpdateString);   // may need to revise
                }
                break;
            }     
        }
        if (!found) {
            // update stats negatively
            gm.updateSocials(-deltaSocial);
            gm.updateAcademics(-deltaAcademics);
            gm.updateStatusField(statusUpdateString);   // may need to revise
        }

        // wait for marker to pass the tick, then grey out the event + update fields
        yield return new WaitForSeconds(2);
        eventName.color = new Color(1, 1, 1, 0.5f);

        gm.updateSocials(deltaSocial);
        gm.updateAcademics(deltaAcademics);
        gm.updateStatusField(statusUpdateString);
    }
}
