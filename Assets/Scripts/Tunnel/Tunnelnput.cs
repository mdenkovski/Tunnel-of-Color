using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tunnelnput : MonoBehaviour
{
    [SerializeField]
    private TunnelSpawnerScript Spawner;

    [SerializeField]
    private float rotationSpeed = 180;
    [SerializeField]
    private float rotationSpeedIcnreaseAmount = 5;
    public bool isRotating = false;
    [SerializeField]
    private int RotationDirection = 0;

    private void Start()
    {
        Spawner = gameObject.GetComponent<TunnelSpawnerScript>();
    }

    private void OnRotateTunnelRight(InputValue input)
    {
        isRotating = input.isPressed;

        if (isRotating)
        {
            RotationDirection = 1;
        }
        else
        {
            RotationDirection = 0;

        }
            //Debug.Log("Rotate Tunnel Right");
    }
    private void OnRotateTunnelLeft(InputValue input)
    {
        isRotating = input.isPressed;

        if (isRotating)
        {
            RotationDirection = -1;
        }
        else
        {
            RotationDirection = 0;

        }
        //Debug.Log("Rotate Tunnel Left");
    }

    private void Update()
    {
        if (isRotating)
        {
            foreach (GameObject Tunnel in Spawner.TunnelSegments)
            {
                Tunnel.transform.Rotate(0, 0, RotationDirection * rotationSpeed * Time.deltaTime);
            }
        }
    }


    public void IncreaseRotationSpeed()
    {
        rotationSpeed += 5;
    }
}
