using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{

    [Header("Tunnel Checking")]
    [SerializeField]
    private Transform GroundTraceLocation;
    [SerializeField]
    private LayerMask GroundLayer;


    [Header("Tunnel")]
    [SerializeField]
    private TunnelSpawnerScript Spawner;

    [Header("Player Information")]
    private PlayerDetails PlayerDetails;
    [SerializeField]
    private Animator Animator;

    public bool IsAlive = true;


    // Start is called before the first frame update
    void Start()
    {
        PlayerDetails = GetComponent<PlayerDetails>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsAlive) return; //if not alive dont check anymore

        RaycastHit hit;
        if (!Physics.Raycast(GroundTraceLocation.position, Vector3.down, out hit, 20.0f, GroundLayer)) return; //if no collision do nothing

        SegmentBehaviour HitSegment = hit.collider.gameObject.GetComponent<SegmentBehaviour>();

        if (PlayerDetails.TargetSegment == HitSegment.SegmentType || HitSegment.SegmentType == SegmentType.White || PlayerDetails.TargetSegment == SegmentType.White)
        {
            //Debug.Log("Safe");
        }
        else
        {
            //Debug.Log("WrongColour");
            Death();
        }

    }

    private void Death()
    {
        IsAlive = false;
        Spawner.StopAllSegments();
        Spawner.GetComponent<PlayerInput>().DeactivateInput();
        Animator.applyRootMotion = true;
        Animator.SetBool("IsDead", true);
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Debug.Log("Hit an Obstacle");
            Death();
            Animator.SetBool("HitFromFront", true);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Obstacle"))
    //    {
    //        Debug.Log("Hit an Obstacle");
    //        Death();
    //    }

    //}


   

}
