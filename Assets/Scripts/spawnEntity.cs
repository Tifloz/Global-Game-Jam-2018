using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.XR.WSA;
using Random = UnityEngine.Random;

public class spawnEntity : MonoBehaviour {

    public GameObject objectSpawn;
    public float minSpawnRadius;
    public float maxSpawnRadius;
    public float timeBetweenSpawn;

    private float _lastSpawn;

	// Use this for initialization
	void Start ()
	{
	    _lastSpawn = Time.time;

	}

    Vector3 GetPointOnPerimeter(float radius, Vector2 vectorPoint)
    {
        var angle = Math.Atan2(vectorPoint.x, vectorPoint.y);
        return new Vector3((float)(radius * Math.Cos(angle)), (float)(radius * Math.Sin(angle)), 0);
    }

	// Update is called once per frame
	void Update () {
        if (Time.time > _lastSpawn + timeBetweenSpawn)
        {
            var distance = Random.Range(minSpawnRadius, maxSpawnRadius);
            var direction = Random.insideUnitCircle;

            var position = GetPointOnPerimeter(distance, direction) + transform.position;
            Instantiate(objectSpawn, position, new Quaternion());
            _lastSpawn = Time.time;
        }
    }
}
