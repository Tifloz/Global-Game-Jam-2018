using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialPickup : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var collector = other.GetComponent<TrialPickupCollector>();
            if (collector != null)
            {
                if (!collector.Completed())
                {
                    collector.Pickup();
                    Destroy(gameObject);
                }
            }
        }
    }
}
