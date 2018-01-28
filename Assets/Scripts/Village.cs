using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour {

    private int _trialCompleted = 0;
    private int _trials;

    private void Start()
    {
        var c = 0;
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Trial"))
                c++;
        }
        _trials = c;
    }

    private int GetTrialCount()
    {
        return _trials;
    }

    public void TrialComplete()
    {
        _trialCompleted++;
        if (_trialCompleted == _trials)
        {
            EnlightZone();
        }
    }

    private void EnlightZone()
    {
        GetComponent<Light>().intensity = 4;
    }
}
