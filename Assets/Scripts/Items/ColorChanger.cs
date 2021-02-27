using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    private SegmentType ColorApplied;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerDetails>().ChangeTagetColor(ColorApplied);

            Destroy(this.gameObject);

        }
        
    }
}
