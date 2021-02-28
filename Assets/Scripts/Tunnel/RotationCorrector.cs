using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCorrector : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
        transform.position = new Vector3(0, 10, transform.position.z);
    }
}
