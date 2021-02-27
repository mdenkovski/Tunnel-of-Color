using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDetails : MonoBehaviour
{
    public SegmentType TargetSegment;


    [SerializeField]
    private Image TargetColorImage;
    [SerializeField]
    private Animator UIAnimation;

    [SerializeField]
    private ParticleSystem PartcleEffect;


    private void Start()
    {
        UpdateColorUI(TargetSegment);
    }

    public void ChangeTagetColor(SegmentType newtarget)
    {
        TargetSegment = newtarget;

        UpdateColorUI(newtarget);
    }

    private void UpdateColorUI(SegmentType newtarget)
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
        UIAnimation.SetBool("IsPlaying", true);
    }


    public void PlayParticleEffect()
    {
        PartcleEffect.Play();
    }

}
