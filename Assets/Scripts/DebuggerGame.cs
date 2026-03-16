using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Corrected namespace

public class DebuggerGame : MonoBehaviour
{
    [Header("UI References")]
    public GameObject debuggerPanel; 
    public Transform gridParent;     
    public GameObject nodePrefab;    
    public TextMeshProUGUI scoreText; // Fixed double semicolon
    public TextMeshProUGUI timerText; // NEW: Timer UI reference

    [Header("Game Settings")]
    public int totalNodes = 12;      
    public int goalBugs = 10;        
    public float bugVisibleTime = 1.0f; 
    public float timeLimit = 20.0f; 

    private List<Button> allButtons = new List<Button>();
    private int bugsCaught = 0;
    private bool isGameRunning = false;
    private int activeBugs = 0; 
    private float currentTime;

    public Friendliness health;

    void Start()
    {
        // Hide panel and build the grid at the start
        debuggerPanel.SetActive(true);
        CreateGrid();
        
        // Auto-start for testing - remove this later for NPC interaction
       Invoke("StartGame", 2f); 
    }

    void CreateGrid()
    {
        // Clear any existing buttons to prevent duplication
        foreach (Transform child in gridParent) { Destroy(child.gameObject); } 
        allButtons.Clear();

        for (int i = 0; i < totalNodes; i++)
        {
            GameObject newBtn = Instantiate(nodePrefab, gridParent);
            Button btn = newBtn.GetComponent<Button>();
            allButtons.Add(btn);
            
            // Assign click event
            btn.onClick.AddListener(() => OnNodeClick(btn));
        }
    }

    public void StartGame()
    {
        if (debuggerPanel == null || scoreText == null || timerText == null)
        {
            Debug.LogError("Please assign all UI References in the Inspector!");
            return;
        }

        debuggerPanel.SetActive(true);
        bugsCaught = 0;
        activeBugs = 0;
        currentTime = timeLimit;
        isGameRunning = true;
        
        UpdateScoreUI();
        UpdateTimerUI();
        
        StartCoroutine(BugSpawner());
        StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine()
    {
        while (isGameRunning && currentTime > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currentTime--;
            UpdateTimerUI();

            if (currentTime <= 0)
            {
                EndGame(false); // Time ran out
            }
        }
    }

    IEnumerator BugSpawner()
    {
        while (isGameRunning && bugsCaught < goalBugs)
        {
            // Only spawn if we are under the 2-bug limit
            if (activeBugs < 2)
            {
                int randomIndex = Random.Range(0, allButtons.Count);
                Button target = allButtons[randomIndex];

                if (target.tag != "Bug")
                {
                    StartCoroutine(FlashBug(target));
                }
            }
            yield return new WaitForSeconds(0.5f);
        }

        if (bugsCaught >= goalBugs && isGameRunning) 
        {
            EndGame(true); // Victory
        }
    }

    IEnumerator FlashBug(Button btn)
    {
        activeBugs++; 
        
        ColorBlock cb = btn.colors;
        cb.normalColor = Color.red;
        cb.highlightedColor = Color.red; // Sync hover color
        cb.selectedColor = Color.red;
        btn.colors = cb;
        btn.tag = "Bug"; 

        yield return new WaitForSeconds(bugVisibleTime);

        // If not clicked, reset and reduce count
        if (btn.tag == "Bug")
        {
            ResetButton(btn);
            activeBugs--; 
        }
    }

    void OnNodeClick(Button clicked)
    {
        if (clicked.tag == "Bug" && isGameRunning)
        {
            bugsCaught++;
            activeBugs--; 
            UpdateScoreUI();
            ResetButton(clicked);
        }
    }

    void ResetButton(Button btn)
    {
        ColorBlock cb = btn.colors;
        Color darkGreen = new Color(0, 0.4f, 0); 
        cb.normalColor = darkGreen; 
        cb.highlightedColor = new Color(0, 0.5f, 0); // Brighter green for hover
        cb.selectedColor = darkGreen;
        btn.colors = cb;
        btn.tag = "Untagged";
    }

    void UpdateScoreUI()
    {
        scoreText.text = "BUGS REPAIRED: " + bugsCaught + "/" + goalBugs;
    }

    void UpdateTimerUI()
    {
        timerText.text = "TIME LEFT: " + currentTime.ToString("0") + "s";
    }

    void EndGame(bool won)
    {
        isGameRunning = false;
        StopAllCoroutines(); 

        if (won)
        {
            scoreText.text = "SYSTEM STABLE!";
            health.GiveHealth(2);

        }
        else
        {
            scoreText.text = "SYSTEM CRASHED!";
        }
        
        Invoke("ClosePanel", 2f);
    }

    void ClosePanel()
    {
        debuggerPanel.SetActive(false);
    }
}