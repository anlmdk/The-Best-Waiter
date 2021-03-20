using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPanel : MonoBehaviour
{
    public GameObject debugMenuPanel;

    public void DebugMenuPanel()
    {
        debugMenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        debugMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
