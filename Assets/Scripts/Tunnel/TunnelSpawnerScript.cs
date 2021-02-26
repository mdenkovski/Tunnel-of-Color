using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelSpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject TunnelPrefab;
    [SerializeField]
    private GameObject BufferPrefab;

    public List<GameObject> TunnelSegments;
    public List<GameObject> BufferSegments;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            

            SpawnNewTunnel(-40 + i * 50);

            SpawnNewBuffer(-50 + i * 50);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnNewTunnel(float distance = 100)
    {
        GameObject tunnel = Instantiate(TunnelPrefab, new Vector3(0, 10, distance), Quaternion.Euler(0,0, 36));
        TunnelBehaviour tunnelbehaviour = tunnel.GetComponent<TunnelBehaviour>();
        tunnelbehaviour.Spawner = this;
        tunnelbehaviour.TunnelType = TunnelType.Color;
        TunnelSegments.Add(tunnel);

        
    }

    public void SpawnNewBuffer(float distance = 100)
    {
        GameObject buffer = Instantiate(BufferPrefab, new Vector3(0, 10, distance), Quaternion.Euler(0, 0, 36));
        TunnelBehaviour tunnelbehaviour = buffer.GetComponent<TunnelBehaviour>();
        tunnelbehaviour.Spawner = this;
        tunnelbehaviour.TunnelType = TunnelType.Buffer;
        BufferSegments.Add(buffer);
    }

}
