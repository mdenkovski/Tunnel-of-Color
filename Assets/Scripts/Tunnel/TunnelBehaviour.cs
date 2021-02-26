using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelBehaviour : MonoBehaviour
{
    [SerializeField]
    private float Speed = 5.0f;

    public TunnelSpawnerScript Spawner;

    [SerializeField]
    private GameObject[] Segments;

    private void Start()
    {
        //a buffer section
        if (Segments.Length == 1) return;

        // assign a unique segment type to each segment
        for (int i = 0; i < (int)SegmentType.Num_Total_Segments; i++)
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
            Spawner.TunnelSegments.Remove(this.gameObject);
            Spawner.SpawnNewTunnel();
            Destroy(gameObject);
        }
    }
}
