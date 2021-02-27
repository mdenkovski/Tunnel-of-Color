using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    private SegmentType ColorApplied;

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerDetails player = other.GetComponent<PlayerDetails>();
            player.ChangeTagetColor(ColorApplied);
            player.PlayParticleEffect();


            Destroy(this.gameObject);

        }
        
    }
}
