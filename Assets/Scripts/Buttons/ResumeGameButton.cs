using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGameButton : MonoBehaviour
{
    [SerializeField]
    private GameObject PausePanel;

    [SerializeField]
    private PlayerBehavior Player;

    public void OnResumeButtonPressed()
    {
        Time.timeScale = 1.0f;

        if (Player != null)
        {
            Player.RunningSound.Play();
        }
        PausePanel.SetActive(false);
    }
}
