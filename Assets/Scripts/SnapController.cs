using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<MemoryBlock> memorySpaces;
    public List<Memory> draggableObjects;
    public float snapRange = 0.4f;

    void Start()
    {
        foreach (Memory mem in draggableObjects)
        {
            mem.dragEndedCallback = OnDragEnded;
        }
    }

    private void OnDragEnded(Memory mem)
    {
        float closestDistance = -1;
        MemoryBlock closestBlock = null;

        foreach(MemoryBlock memBlock in memorySpaces)
        {
            float currentDistance = Vector2.Distance(mem.transform.position, memBlock.transform.position);
            if (closestBlock == null || currentDistance < closestDistance)
            {
                closestBlock = memBlock;
                closestDistance = currentDistance;
            }
        }

        if (closestBlock != null && closestDistance <= snapRange && !closestBlock.isOccupied)
        {
            mem.transform.position = closestBlock.transform.position;
            closestBlock.isOccupied = true;
            closestBlock.heldMem = mem;
            mem.snappedTo = closestBlock;
            mem.snappedToLast.isOccupied = false;
            mem.snappedToLast = null;
        }

        else 
        {
            mem.transform.position = mem.lastPosition;

            if (mem.snappedToLast != null)
            {
                mem.snappedTo = mem.snappedToLast;
                mem.snappedTo.isOccupied = true;
                mem.snappedTo.heldMem = mem;
                mem.snappedToLast = null;
            }
        }

    }

    public void addDraggable(Memory mem)
    {
        mem.dragEndedCallback = OnDragEnded;
        draggableObjects.Add(mem);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Memory mem in draggableObjects)
        {
            if (mem == null)
                draggableObjects.Remove(mem);
        }
    }
}
