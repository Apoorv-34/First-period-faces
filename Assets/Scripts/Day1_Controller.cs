using UnityEngine;

public class Day1_Controller : MonoBehaviour
{
    [Header("World Elements")]
    [Tooltip("Drag the 'Manager' object here to hide characters/environment.")]
    public GameObject worldObject; 

    [Header("Player Panels")]
    [Tooltip("0: Nerd, 1: Fashion, 2: Sport")]
    public GameObject[] playerPanels; 

    /// <summary>
    /// This hides the world (Manager) and opens ONLY the selected panel.
    /// </summary>
    public void OpenPanel(int panelIndex)
    {
        // 1. Basic Index Validation
        if (panelIndex < 0 || panelIndex >= playerPanels.Length)
        {
            Debug.LogWarning("Panel Index " + panelIndex + " is out of range!");
            return;
        }

        // 2. Hide only the Manager (World) 
        // The Canvas stays visible so your UI buttons keep working.
        if (worldObject != null)
        {
            worldObject.SetActive(false);
        }

        // 3. Simple loop to handle the panels
        for (int i = 0; i < playerPanels.Length; i++)
        {
            if (playerPanels[i] != null)
            {
                // If i matches our index, it becomes true (Active). 
                // All others become false (Inactive).
                playerPanels[i].SetActive(i == panelIndex);
            }
        }
    }

    /// <summary>
    /// Call this from a 'Back' or 'Close' button inside your panels.
    /// </summary>
    public void CloseAllPanels()
    {
        // Show the world (Manager) again
        if (worldObject != null)
        {
            worldObject.SetActive(true);
        }

        // Hide every panel in the list
        foreach (GameObject panel in playerPanels)
        {
            if (panel != null)
            {
                panel.SetActive(false);
            }
        }
    }
}