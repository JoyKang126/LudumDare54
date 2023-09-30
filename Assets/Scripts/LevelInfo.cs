using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    public List<MemoryInfo> memoryList = new List<MemoryInfo>();

    public MemoryInfo getNextMemory()
    {
        if (memoryList.Count > 0)
        {
            MemoryInfo removed = memoryList[0];
            memoryList.RemoveAt(0);
            return removed;
            
        }
        else 
        {
            return null;
        }
    }
}
