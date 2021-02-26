using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum SegmentType
{
    Red,
    Green,
    Blue,
    Yellow,
    Black,
    White,
    Num_Total_Segments
}

public class SegmentBehaviour : MonoBehaviour
{
    [SerializeField]
    public SegmentType SegmentType = SegmentType.White;

   

    public void SetSegmentType(SegmentType newType)
    {
        SegmentType = newType;
        MeshRenderer Mesh = GetComponent<MeshRenderer>();
        switch (SegmentType)
        {
            case SegmentType.Red:
                Mesh.material.color = Color.red;
                break;
            case SegmentType.Green:
                Mesh.material.color = Color.green;
                break;
            case SegmentType.Blue:
                Mesh.material.color = Color.blue;
                break;
            case SegmentType.Yellow:
                Mesh.material.color = Color.yellow;
                break;
            case SegmentType.Black:
                Mesh.material.color = Color.black;
                break;
            case SegmentType.White:
                Mesh.material.color = Color.white;
                break;
            default:
                break;
        }
    }
}
