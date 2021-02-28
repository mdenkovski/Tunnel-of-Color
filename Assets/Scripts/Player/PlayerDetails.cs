using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDetails : MonoBehaviour
{
    public SegmentType TargetSegment;


    [SerializeField]
    private Image TargetColorImage;
    [SerializeField]
    private Animator UIAnimation;

    [SerializeField]
    private ParticleSystem PartcleEffect;

    [SerializeField]
    private AudioSource PowerupSound;

    public int NumSegmentsPassed = 0;

    [SerializeField]
    private TMP_Text NumSegemntsText;

    private void Start()
    {
        UpdateColorUI(TargetSegment, false);
        UpdateScoreUI();
    }

    public void ChangeTagetColor(SegmentType newtarget)
    {
        TargetSegment = newtarget;

        UpdateColorUI(newtarget);
    }

    private void UpdateColorUI(SegmentType newtarget, bool animated = true)
    {
        Color ColorToUpdate;

        switch (TargetSegment)
        {
            case SegmentType.Red:
                ColorToUpdate = Color.red;
                break;
            case SegmentType.Green:
                ColorToUpdate = Color.green;
                break;
            case SegmentType.Blue:
                ColorToUpdate = Color.blue;
                break;
            case SegmentType.Yellow:
                ColorToUpdate = Color.yellow;
                break;
            case SegmentType.Black:
                ColorToUpdate = Color.black;
                break;
            case SegmentType.White:
                ColorToUpdate = Color.white;
                break;
            default:
                ColorToUpdate = Color.clear;
                break;
        }

        TargetColorImage.color = ColorToUpdate;
        UIAnimation.SetBool("IsPlaying", animated);
    }


    public void PlayParticleEffect()
    {
        PartcleEffect.Play();
        PowerupSound.Play();
    }

    public void IncreaseSegmentsPassed()
    {
        NumSegmentsPassed++;
        UpdateScoreUI();

        
    }

    private void UpdateScoreUI()
    {
        NumSegemntsText.text = NumSegmentsPassed.ToString();
    }

    public void AssignRandomColor()
    {
        //chenge to a randome color after every 10 segments
        if (NumSegmentsPassed % 10 == 0)
        {
            ChangeTagetColor((SegmentType)Random.Range(0, 4));
            PlayParticleEffect();
        }
    }

}
