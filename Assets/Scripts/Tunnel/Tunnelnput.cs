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
    //[SerializeField]
    //private float rotationSpeedIcnreaseAmount = 5;
    public bool isRotating = false;
    [SerializeField]
    private int RotationDirection = 0;

    //each 5th of the cylinder is 72 degrees, 80 gives some buffer room
    private const float MAX_ROTATION_ANGLE = 85.0f;
    //each buffer is 10 long so use 9 to give some room for reaction time
    private const float BUFFER_LENGTH = 9.0f;

    private void Start()
    {
        Spawner = gameObject.GetComponent<TunnelSpawnerScript>();
        UpdateRotationSpeed();
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


    public void UpdateRotationSpeed()
    {
        float currentSpeed = Spawner.TunnelSpeed;

        float timeToPassBuffer = BUFFER_LENGTH / currentSpeed; //each buffer is 10 long 

        float newRotationSpeed = MAX_ROTATION_ANGLE / timeToPassBuffer;


        //aplly the greater of the new rotation speed or 180
        //rotationSpeed = (newRotationSpeed > 180)? newRotationSpeed: 180;

        rotationSpeed = newRotationSpeed;
    }
}
