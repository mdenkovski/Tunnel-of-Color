using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelSpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject ColorTunnelPrefab;
    [SerializeField]
    private GameObject ObstacleTunnelPrefab;
    [SerializeField]
    private GameObject RotatingTunnelPrefab;
    [SerializeField]
    private GameObject DifficultyInceaseTunnelPrefab;
    [SerializeField]
    private GameObject BufferPrefab;

    public List<GameObject> TunnelSegments;
    public List<GameObject> BufferSegments;

    [SerializeField]
    private TunnelType StartingGroupType;

    [Header("Tunnel Movement")]
    public float TunnelSpeed;
    [SerializeField]
    private float SpeedIncreaseAmount;

    


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            SpawnNewTunnel(StartingGroupType, -40 + i * 50);

            SpawnNewBuffer(-50 + i * 50);
        }

        Random.InitState(System.DateTime.Now.Millisecond);

    }

    

    public void SpawnNewTunnel(TunnelType newType, float distance = 100)
    {
        //chose a random tunnel based on a probability
        if (newType == TunnelType.Random)
        {
            float roll = Random.Range(0.0f, 100.0f);

            if (roll < 10)
            {
                newType = TunnelType.Rotating;

            }
            else if (roll < 20)
            {
                newType = TunnelType.Obstacle;
            }
            else if (roll < 30)
            {
                newType = TunnelType.DifficultyIncrease;
            }
            else //color tunnel is the most often
            {
                newType = TunnelType.Color;
            }

        }

        //chose the prefab to spawn based on the new type
        GameObject prefabToSpawn;
        switch (newType)
        {
            
            case TunnelType.Color:
                prefabToSpawn = ColorTunnelPrefab;
                break;
            case TunnelType.Obstacle:
                prefabToSpawn = ObstacleTunnelPrefab;
                break;
            case TunnelType.White:
                prefabToSpawn = ColorTunnelPrefab;
                break;
            case TunnelType.Rotating:
                prefabToSpawn = RotatingTunnelPrefab;
                break;
            case TunnelType.DifficultyIncrease:
                prefabToSpawn = DifficultyInceaseTunnelPrefab;
                break;
            default:
                prefabToSpawn = ColorTunnelPrefab;
                break;
        }

        //spawn in the new segment
        GameObject tunnel = Instantiate(prefabToSpawn, new Vector3(0, 10, distance), Quaternion.Euler(0,0, 36));
        TunnelBehaviour tunnelbehaviour = tunnel.GetComponent<TunnelBehaviour>();
        tunnelbehaviour.Spawner = this;
        tunnelbehaviour.TunnelType = newType;
        tunnelbehaviour.UpdateSpeed(TunnelSpeed);
        TunnelSegments.Add(tunnel);

        
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

    public void IncreaseDifficulty()
    {
        TunnelSpeed += SpeedIncreaseAmount;
        GetComponent<Tunnelnput>().UpdateRotationSpeed();


        //apply the speed change to the segments
        IncreaseSpeed();
        //Debug.Log("Speed Increased");
    }



}
