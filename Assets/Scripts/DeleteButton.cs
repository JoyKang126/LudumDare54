using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (transform.parent.gameObject.GetComponent<Memory>().snappedTo != null)
            transform.parent.gameObject.GetComponent<Memory>().snappedTo.isOccupied = false;
        Destroy(transform.parent.gameObject);
    }
}
