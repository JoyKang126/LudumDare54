using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayTrigger : MonoBehaviour
{
    [SerializeField] private TMP_Text dayText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other) {
        dayText.color = new Color(0.5764706f, 0.8313726f, 0.9843138f, 1);
    }

    public void OnTriggerExit2D(Collider2D other) {
        dayText.color = new Color(1, 1, 1, 1);
    }
}
