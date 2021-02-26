using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tunnelnput : MonoBehaviour
{
    [SerializeField]
    private TunnelSpawnerScript Spawner;

    private void Start()
    {
        Spawner = gameObject.GetComponent<TunnelSpawnerScript>();
    }

    private void OnRotateTunnelRight(InputValue input)
    {
        if (input.isPressed)
        {
            Debug.Log("Rotate Tunnel Right");

            foreach (GameObject Tunnel in Spawner.TunnelSegments)
            {
                Tunnel.transform.Rotate(0,0,72);
            }
        }
    }
    private void OnRotateTunnelLeft(InputValue input)
    {
        if (input.isPressed)
        {
            foreach (GameObject Tunnel in Spawner.TunnelSegments)
            {
                Tunnel.transform.Rotate(0, 0, -72);
            }
            Debug.Log("Rotate Tunnel Left");
        }
    }


}
