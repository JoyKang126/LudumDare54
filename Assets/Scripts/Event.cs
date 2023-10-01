using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Event : MonoBehaviour
{
    [SerializeField] private List<string> requirements = new List<string>();
    [SerializeField] private GameManager gm;
    [SerializeField] private TMP_Text eventName;
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
        float deltaSocial = 0f;
        float deltaAcademics = 0f;
        string statusUpdateString = "";
        
        // if (memblocks contain required memory id) {
        //     // update stats positively
        // }
        // else {
        //     // update stats negatively
        // }

        // wait for marker to pass the tick, then grey out the event + update fields
        yield return new WaitForSeconds(2);
        eventName.color = new Color(1, 1, 1, 0.5f);

        gm.updateSocials(deltaSocial);
        gm.updateAcademics(deltaAcademics);
        gm.updateStatusField(statusUpdateString);
    }
}
