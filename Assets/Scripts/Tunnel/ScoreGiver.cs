using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGiver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GetComponent<TunnelBehaviour>().TunnelType == TunnelType.White) return;//dont add score if a white tunnel

            other.gameObject.GetComponent<PlayerDetails>().IncreaseSegmentsPassed();
        }
    }
}
