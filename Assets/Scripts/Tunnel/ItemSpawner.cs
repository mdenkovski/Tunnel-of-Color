using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] ItemsToSpawn;

    [SerializeField]
    private GameObject[] ItemSpawnLocations;




    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject Location in ItemSpawnLocations)
        {
            Instantiate(ItemsToSpawn[Random.Range(0, ItemsToSpawn.Length)], Location.transform, false);
        }
    }

    
}
