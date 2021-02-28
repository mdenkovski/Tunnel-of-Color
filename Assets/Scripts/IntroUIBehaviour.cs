using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroUIBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ItemsToShow;

    private int CurrentItem = 0;

    [SerializeField]
    private float TotalDecondsToDisplay = 13.0f;
    private float numSecondsToShowEach;

    // Start is called before the first frame update
    void Start()
    {
        numSecondsToShowEach = TotalDecondsToDisplay / ItemsToShow.Length;
        StartCoroutine(ShowNextItem());
    }

   IEnumerator ShowNextItem()
    {
        ItemsToShow[CurrentItem].SetActive(true);
        CurrentItem++;
        yield return new WaitForSeconds(numSecondsToShowEach);
        if (CurrentItem != ItemsToShow.Length)
        {
            StartCoroutine(ShowNextItem());

        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
