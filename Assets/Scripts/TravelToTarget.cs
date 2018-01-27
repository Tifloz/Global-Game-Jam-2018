using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelToTarget : MonoBehaviour {

    public Vector2 Target;
    public float Speed = 5;
    
    private Rigidbody2D _body;
    private Action<Vector2> _taskAtDest;
	// Use this for initialization
	void Start () {
        _body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (_body.position == Target)
        {
            _body.velocity = Vector2.zero;
            _taskAtDest(_body.position);
            Destroy(this);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Target, Speed * Time.deltaTime);
        }
	}

    public void AtDestination(Action<Vector2> task)
    {
        _taskAtDest = task;
    }
}
