using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Memory : MonoBehaviour
{
    public static List<Memory> memories = new List<Memory>();
    // Start is called before the first frame update
    public delegate void DragEndedDelegate(Memory mem);
    public DragEndedDelegate dragEndedCallback;

    [SerializeField] private TMP_Text description;

    public string memID;
    public string memDesc;
    private bool isDragged = false;
    private bool clicked;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    public Vector3 lastPosition;
    public MemoryBlock snappedTo;
    public MemoryBlock snappedToLast;

    void Start()
    {
        memories.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        //delete button
        if(clicked)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        description.text = memDesc;
    }

    private void OnMouseDown()
    {
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
        lastPosition = transform.position; //save in case of bad movement
        if (snappedTo != null)
        {
            snappedToLast = snappedTo;
            snappedTo.heldMem = null;
            //snappedTo.isOccupied = false;
            snappedTo = null;
        }  
    }

    private void OnMouseDrag()
    {
        foreach(Memory obj in memories)
        {
            obj.clicked = false;
        }
        if(isDragged)
        {
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }

    private void OnMouseUp()
    {
        isDragged = false;
        if (transform.localPosition == spriteDragStartPosition)
        {
            clicked = true;
            foreach(Memory obj in memories)
            {
                if(obj != this)
                {
                    obj.clicked = false;
                }
            }
        }
        dragEndedCallback(this);
    }

}
