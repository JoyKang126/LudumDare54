using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float academicsmeter;
    [SerializeField] private float happinessmeter;
    [SerializeField] private LevelInfo levelInfo;
    [SerializeField] private TMP_Text queueTimer;
    [SerializeField] public SnapController snapControl;
    [SerializeField] public List<MemoryBlock> queueSpaces;
    [SerializeField] public List<MemoryBlock> memSpaces;
    [SerializeField] public TMP_Text statusField;
    [SerializeField] public MeterTick academicsMeter;
    [SerializeField] public MeterTick happyMeter;
    [SerializeField] public Portrait portrait;

    [SerializeField] private GameObject performanceError;
    [SerializeField] private GameObject queueError;
    
    private float timer = 3;
    //private gameObject heldMem;
    public bool isHolding;
    public GameObject memPrefab;


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("bgm");
        happinessmeter = 0;
        academicsmeter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //update meters
        academicsMeter.updateMeter(academicsmeter);
        happyMeter.updateMeter(happinessmeter);

        if((academicsmeter < -4 || happinessmeter < -4) && Time.timeScale > 0f)
        {
            //trigger endstate
            endGamePerformance();
        }

        if (timer > 0)
        {
            queueTimer.text = string.Format("(Loading: {0:00})", timer);
            timer -= Time.deltaTime;
            // Debug.Log(timer);
        }
        else
        {
            //spawn new memory
            MemoryInfo nextmem = levelInfo.getNextMemory();
            if (nextmem != null)
            {
                //find first available queue space
                Vector3 pos = new Vector3(0,0,0);
                MemoryBlock selected = null;
                foreach (MemoryBlock queue in queueSpaces)
                {
                    if (!queue.isOccupied)
                    {
                        pos = queue.transform.position;
                        queue.isOccupied = true;
                        selected = queue;
                        break;
                    }
                        
                }
                if (selected != null)
                {
                    //create a new memory block at the spot found above
                    FindObjectOfType<AudioManager>().Play("newmemory");
                    GameObject mem = Instantiate (memPrefab, pos, Quaternion.identity);
                    mem.GetComponent<Memory>().snappedTo = selected;
                    selected.heldMem = mem.GetComponent<Memory>();
                    mem.GetComponent<Memory>().memID = nextmem.memID;
                    mem.GetComponent<Memory>().memDesc = nextmem.memDescription;
                    mem.SetActive(true);
                    snapControl.addDraggable(mem.GetComponent<Memory>());
                }
                else
                {
                    //queue is full
                    //trigger end game state
                    endGameQueue();
                }
                
            }
            timer = 3;
        }

    }

    public void updateHappiness(float change)
    {
        if (happinessmeter < 5)
        {
            happinessmeter += change;
        }
    }

    public void updateAcademics(float change)
    {
        if (academicsmeter < 5)
        {
            academicsmeter += change;
        }
    }

    public void updateStatusField(string content)
    {
        statusField.text = content;
    }

    public void endGamePerformance() {
        // implement endgame, load end game screen
        FindObjectOfType<AudioManager>().Play("poperror");
        FindObjectOfType<AudioManager>().StopPlay("bgm");
        performanceError.SetActive(true);
        Time.timeScale = 0f;
    }

    public void endGameQueue() {
        // implement endgame, load end game screen
        FindObjectOfType<AudioManager>().Play("poperror");
        FindObjectOfType<AudioManager>().StopPlay("bgm");
        queueError.SetActive(true);
        Time.timeScale = 0f;
    }

    public void endGame() {
        // implement endgame, load end game screen
        float score = happinessmeter + academicsmeter;
        if (score < -2f)
        {
            FindObjectOfType<AudioManager>().StopPlay("bgm");
            SceneManager.LoadScene("BadEnding");
        }
        else if (score > 4f)
        {
            FindObjectOfType<AudioManager>().StopPlay("bgm");
            SceneManager.LoadScene("GoodEnding");
        }
        else
        {
            FindObjectOfType<AudioManager>().StopPlay("bgm");
            SceneManager.LoadScene("NeutralEnding");
        }
    }
}
