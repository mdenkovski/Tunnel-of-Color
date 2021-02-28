using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyIncreaser : MonoBehaviour
{
    [SerializeField]
    private GameObject SpeedArrows;

    private void Start()
    {
        Instantiate(SpeedArrows, transform, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<TunnelBehaviour>().Spawner.IncreaseDifficulty();
            other.gameObject.GetComponent<PlayerDetails>().AssignRandomColor();
        }
    }
}
