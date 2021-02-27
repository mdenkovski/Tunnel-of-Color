using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGameButton : MonoBehaviour
{
    [SerializeField]
    private GameObject PausePanel;

    public void OnResumeButtonPressed()
    {
        Time.timeScale = 1.0f;
        PausePanel.SetActive(false);
    }
}
