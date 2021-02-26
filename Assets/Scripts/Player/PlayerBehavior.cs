using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    [Header("Tunnel Checking")]
    [SerializeField]
    private Transform GroundTraceLocation;
    [SerializeField]
    private LayerMask GroundLayer;

    private PlayerDetails PlayerDetails;


    // Start is called before the first frame update
    void Start()
    {
        PlayerDetails = GetComponent<PlayerDetails>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (!Physics.Raycast(GroundTraceLocation.position, Vector3.down, out hit, 20.0f, GroundLayer)) return; //if no collision do nothing

        SegmentBehaviour HitSegment = hit.collider.gameObject.GetComponent<SegmentBehaviour>();

        if (PlayerDetails.TargetSegment == HitSegment.SegmentType || HitSegment.SegmentType == SegmentType.White || PlayerDetails.TargetSegment == SegmentType.White)
        {
            Debug.Log("Safe");
        }
        else
        {
            Debug.Log("WrongColour");
        }

    }
}
