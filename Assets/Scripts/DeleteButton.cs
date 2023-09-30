using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (transform.parent.gameObject.GetComponent<Memory>().snappedTo != null)
            transform.parent.gameObject.GetComponent<Memory>().snappedTo.isOccupied = false;
        Destroy(transform.parent.gameObject);
    }
}
