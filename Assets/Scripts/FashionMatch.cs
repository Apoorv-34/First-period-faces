using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FashionMatch : MonoBehaviour
{
    [Header("UI References")]
    public GameObject fashionPanel;
    public Transform gridParent;
    public GameObject nodePrefab;
    public TextMeshProUGUI trendText;
    public TextMeshProUGUI scoreText;

    [Header("Game Settings")]
    public int totalButtons = 12;
    public int goalMatches = 5;

    // NEW: List of possible trend colors (Neon Pink, Electric Blue, Lime Green)
    private List<Color> potentialTrends = new List<Color> {
        new Color(1f, 0f, 0.8f),    // Neon Pink
        new Color(0f, 0.5f, 1f),    // Electric Blue
        new Color(0.2f, 1f, 0.2f)   // Lime Green
    };

    private Color currentBaseColor;
    private List<Button> allButtons = new List<Button>();
    private int matchesFound = 0;
    private bool isGameRunning = false;

    void Start()
    {
        fashionPanel.SetActive(false);
        CreateGrid();
    }

    public void StartGame()
    {
        fashionPanel.SetActive(true);
        matchesFound = 0;
        isGameRunning = true;

        // NEW: Pick a random trend from the list
        currentBaseColor = potentialTrends[Random.Range(0, potentialTrends.Count)];
        UpdateTrendText();

        AssignShades();
        UpdateUI();
    }

void AssignShades()
{
    // 1. Reset all buttons to random non-trend colors
    foreach (Button btn in allButtons)
    {
        btn.image.color = new Color(Random.value, Random.value, Random.value);
        btn.tag = "Untagged";
    }

    // 2. Convert base trend color to HSV
    float baseH, baseS, baseV;
    Color.RGBToHSV(currentBaseColor, out baseH, out baseS, out baseV);

    // 3. Pick unique buttons for trend shades
    List<int> usedIndices = new List<int>();

    for (int i = 0; i < goalMatches; i++)
    {
        int index;
        do
        {
            index = Random.Range(0, allButtons.Count);
        } while (usedIndices.Contains(index));

        usedIndices.Add(index);

        // 4. Create DIFFICULT shades
        // Same hue, but strong variation in saturation & brightness
        float shadeS = Mathf.Clamp(Random.Range(0.35f, 1f), 0.35f, 1f);
        float shadeV = Mathf.Clamp(Random.Range(0.35f, 1f), 0.35f, 1f);

        Color shadeColor = Color.HSVToRGB(baseH, shadeS, shadeV);

        allButtons[index].image.color = shadeColor;
        allButtons[index].tag = "Trend";
    }
}


    void UpdateTrendText()
    {
        if (currentBaseColor.r > 0.8f) trendText.text = "TREND: NEON SHADES";
        else if (currentBaseColor.b > 0.8f) trendText.text = "TREND: ELECTRIC SHADES";
        else trendText.text = "TREND: LIME SHADES";
        
        trendText.color = currentBaseColor;
    }

    void OnColorClick(Button clicked)
    {
        if (clicked.tag == "Trend" && isGameRunning)
        {
            matchesFound++;
            clicked.image.color = Color.gray; // "Disable" it visually
            clicked.tag = "Untagged";
            UpdateUI();

            if (matchesFound >= goalMatches) WinGame();
        }
    }

    // Reuse your previous helper functions (CreateGrid, UpdateUI, WinGame, etc.)
    void CreateGrid()
    {
        foreach (Transform child in gridParent) { Destroy(child.gameObject); }
        allButtons.Clear();
        for (int i = 0; i < totalButtons; i++)
        {
            GameObject newBtn = Instantiate(nodePrefab, gridParent);
            Button btn = newBtn.GetComponent<Button>();
            allButtons.Add(btn);
            btn.onClick.AddListener(() => OnColorClick(btn));
        }
    }
    void UpdateUI() => scoreText.text = "MATCHES: " + matchesFound + "/" + goalMatches;
    void WinGame() { isGameRunning = false; trendText.text = "STUNNING!"; Invoke("ClosePanel", 2f); }
    void ClosePanel() => fashionPanel.SetActive(false);
}