using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum TunnelType
{
    Buffer,
    Color
}

public class TunnelBehaviour : MonoBehaviour
{
    [SerializeField]
    private float Speed = 5.0f;

    public TunnelSpawnerScript Spawner;

    [SerializeField]
    private GameObject[] Segments;

    public TunnelType TunnelType;

    private void Start()
    {
        //a buffer section
        if (TunnelType == TunnelType.Buffer) return;

        // assign a unique segment type to each segment
        for (int i = 0; i < (int)SegmentType.Num_Total_Segments -1; i++)
        {
            GameObject SegmentToChange;
            //get a random segment
            bool foundUnassignedSegment = false;
            SegmentToChange = Segments[Random.Range(0, Segments.Length)];
            while (!foundUnassignedSegment)
            {

                if (SegmentToChange.GetComponent<SegmentBehaviour>().SegmentType == SegmentType.White) // have reached a segment to edit
                {
                    foundUnassignedSegment = true;
                }
                else // if there is already a set segment get a different one
                {
                    SegmentToChange = Segments[Random.Range(0, Segments.Length)];
                }
            }

            SegmentToChange.GetComponent<SegmentBehaviour>().SetSegmentType((SegmentType)i);

        }
            
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * Speed * Time.deltaTime;

        if (transform.position.z < -100)
        {
            if (TunnelType == TunnelType.Buffer) // a bufer tunnel
            {
                Spawner.BufferSegments.Remove(this.gameObject);
                Spawner.SpawnNewBuffer();
                Destroy(gameObject);
            }
            else if (TunnelType == TunnelType.Color) // a regular tunnel
            {
                Spawner.TunnelSegments.Remove(this.gameObject);
                Spawner.SpawnNewTunnel();
                Destroy(gameObject);
            }

        }
    }
}
