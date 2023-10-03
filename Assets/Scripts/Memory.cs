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
    public bool isDragged = false;
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
        if(Time.timeScale > 0f)
        {
            isDragged = true;
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "drag";
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "drag";
            transform.GetChild(1).gameObject.GetComponent<Canvas>().sortingLayerName = "drag";
            transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "drag";

            FindObjectOfType<AudioManager>().Play("click");
            mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spriteDragStartPosition = transform.localPosition;
            lastPosition = transform.position; //save in case of bad movement
            if (snappedTo != null)
            {
                snappedToLast = snappedTo;
                //snappedTo.heldMem = null;
                //snappedTo.isOccupied = false;
                //snappedTo = null;
            } 
        }
    }

    private void OnMouseDrag()
    {
        if(Time.timeScale > 0f)
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
        
    }

    private void OnMouseUp()
    {
        if(Time.timeScale > 0f)
        {
            isDragged = false;
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "notdrag";
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "notdrag";
            transform.GetChild(1).gameObject.GetComponent<Canvas>().sortingLayerName = "notdrag";
            transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "notdrag";
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
            else
            {
                FindObjectOfType<AudioManager>().Play("drop");
            }
            dragEndedCallback(this);
            }
    }

    public void recoverAfterPause()
    {
        isDragged = false;
        gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "notdrag";
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "notdrag";
        transform.GetChild(1).gameObject.GetComponent<Canvas>().sortingLayerName = "notdrag";
        transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "notdrag";

        transform.position = lastPosition;

        if (snappedToLast != null)
        {
            snappedTo = snappedToLast;
            snappedTo.isOccupied = true;
            snappedTo.heldMem = this;
            snappedToLast = null;
        }
    }

}


