using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroUIBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ItemsToShow;

    private int CurrentItem = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowNextItem());
    }

   IEnumerator ShowNextItem()
    {
        ItemsToShow[CurrentItem].SetActive(true);
        CurrentItem++;
        yield return new WaitForSeconds(3.0f);
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
