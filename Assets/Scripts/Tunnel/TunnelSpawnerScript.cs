using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelSpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject TunnelPrefab;

    public List<GameObject> TunnelSegments;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            //newTunnel.GetComponent<TunnelBehaviour>().Spawner = this;
            GameObject tunnel = Instantiate(TunnelPrefab, new Vector3(0, 10, -50 + i * 50), Quaternion.Euler(0, 0, 36 + Random.Range(0, 5) * 72));
            tunnel.GetComponent<TunnelBehaviour>().Spawner = this;
            TunnelSegments.Add(tunnel);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnNewTunnel()
    {
        GameObject tunnel = Instantiate(TunnelPrefab, new Vector3(0, 10, 100), Quaternion.Euler(0,0, 36 + Random.Range(0,5) * 72));
        tunnel.GetComponent<TunnelBehaviour>().Spawner = this;
        TunnelSegments.Add(tunnel);
    }

}
