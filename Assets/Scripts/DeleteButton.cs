using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        if(Time.timeScale > 0f)
        {
            if (transform.parent.gameObject.GetComponent<Memory>().snappedTo != null)
                transform.parent.gameObject.GetComponent<Memory>().snappedTo.isOccupied = false;
            FindObjectOfType<AudioManager>().Play("delete");
            Destroy(transform.parent.gameObject);
        }
    }
}
