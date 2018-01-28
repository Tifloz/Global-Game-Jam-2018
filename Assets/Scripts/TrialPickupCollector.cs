using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialPickupCollector : MonoBehaviour {

    // Use this for initialization
    public int PickupGoal;
    public int Current;
    public GameObject Spawner;

    public void Start()
    {
        Current = 0;
    }

    public void Pickup()
    {
        if (Current < PickupGoal)
            Current += 1;
    }

    public void Reset()
    {
        Current = 0;
    }

    public bool Completed()
    {
        return Current == PickupGoal;
    }

    void Update()
    {
        if (Completed())
        {
            Spawner.GetComponent<UpgradeChoice>().LaunchUpgrades();
            Destroy(this);
        }
    }
}
