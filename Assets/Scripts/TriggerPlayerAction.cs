using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayerAction : MonoBehaviour {

    private bool _activated = false;

	// Use this for initialization
	void Start () {
	}

    public bool Activated()
    {
        return _activated;
    }

    public void Activate(bool activation)
    {
        _activated = activation;
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!_activated)
        {
            if (collision.CompareTag("Player"))
            {
                if (Input.GetButton("Action"))
                {
                    this.OnActionTrigger(collision.gameObject);
                }
            }
        }
    }

    protected virtual void OnActionTrigger(GameObject player) {
    }
}
