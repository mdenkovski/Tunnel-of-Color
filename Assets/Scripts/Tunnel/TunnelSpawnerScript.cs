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

    [Header("Tunnel Movement")]
    [SerializeField]
    private int NumSegmentsSpawned;
    [SerializeField]
    private int SpeedIncreaseInterval;
    [SerializeField]
    private float TunnelSpeed;
    [SerializeField]
    private float SpeedIncreaseAmount;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            SpawnNewTunnel(TunnelType.White, -40 + i * 50);

            SpawnNewBuffer(-50 + i * 50);
        }
    }

    

    public void SpawnNewTunnel(TunnelType newType, float distance = 100)
    {
        GameObject tunnel = Instantiate(TunnelPrefab, new Vector3(0, 10, distance), Quaternion.Euler(0,0, 36));
        TunnelBehaviour tunnelbehaviour = tunnel.GetComponent<TunnelBehaviour>();
        tunnelbehaviour.Spawner = this;
        tunnelbehaviour.TunnelType = newType;
        tunnelbehaviour.UpdateSpeed(TunnelSpeed);
        TunnelSegments.Add(tunnel);

        NumSegmentsSpawned++;

        if (NumSegmentsSpawned >= SpeedIncreaseInterval)
        {
            TunnelSpeed += 1;
            IncreaseSpeed();
            NumSegmentsSpawned = 0;
            Debug.Log("Speed Increased");
        }
    }

    public void SpawnNewBuffer(float distance = 100)
    {
        GameObject buffer = Instantiate(BufferPrefab, new Vector3(0, 10, distance), Quaternion.Euler(0, 0, 36));
        TunnelBehaviour tunnelbehaviour = buffer.GetComponent<TunnelBehaviour>();
        tunnelbehaviour.Spawner = this;
        tunnelbehaviour.TunnelType = TunnelType.Buffer;
        tunnelbehaviour.UpdateSpeed(TunnelSpeed);
        BufferSegments.Add(buffer);
    }

    public void StopAllSegments()
    {
        foreach (GameObject TunnelSegment in TunnelSegments)
        {
            TunnelSegment.GetComponent<TunnelBehaviour>().IsActive = false;
        }
        
        foreach (GameObject TunnelSegment in BufferSegments)
        {
            TunnelSegment.GetComponent<TunnelBehaviour>().IsActive = false;
        }

    }

    private void IncreaseSpeed()
    {
        foreach (GameObject TunnelSegment in TunnelSegments)
        {
            TunnelSegment.GetComponent<TunnelBehaviour>().UpdateSpeed(TunnelSpeed);
        }

        foreach (GameObject TunnelSegment in BufferSegments)
        {
            TunnelSegment.GetComponent<TunnelBehaviour>().UpdateSpeed(TunnelSpeed);
        }
    }


}
