using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEntity : MonoBehaviour {

    public GameObject objectSpawn;
    public Light objectLight;
    public float MaxDistSpawn;
    public int numberMax;
    public float timeBetweenSpawn;
    private Vector2 _MinDistSpawnPos;
    private Vector2 _MinDistSpawnNeg;
    private float _lastSpawn;
    private Vector3 _position;
    private Vector3 _transform;

	// Use this for initialization
	void Start () {
        _lastSpawn = Time.time;
        _transform = GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > _lastSpawn + timeBetweenSpawn)
        {
            Random.InitState((int)System.DateTime.Now.Ticks);
            _position = Random.insideUnitSphere * MaxDistSpawn + GetComponent<Transform>().parent.GetComponent<Transform>().position;
            _position.z = 0;

            _MinDistSpawnPos.x = objectLight.range + _transform.x;
            _MinDistSpawnPos.y = objectLight.range + _transform.y;

            _MinDistSpawnNeg.x = -objectLight.range - _transform.x;
            _MinDistSpawnNeg.y = -objectLight.range - _transform.y;

            if (((_position.x < _MinDistSpawnPos.x && _position.x > _transform.x) || (_position.x < _MinDistSpawnNeg.x && _position.x < _transform.x))  && 
                ((_position.y < _MinDistSpawnPos.y && _position.y > _transform.y) || (_position.y < _MinDistSpawnNeg.y && _position.y < _transform.y)))
            {
                if (Random.Range(-1, 1) < 0)
                    _position.y = (_position.y < 0) ? _MinDistSpawnNeg.y : _MinDistSpawnPos.y;
                else
                    _position.x = (_position.x < 0) ? _MinDistSpawnNeg.x : _MinDistSpawnPos.x;
            }
                Instantiate(objectSpawn, _position, new Quaternion());
            _lastSpawn = Time.time;
        }
    }
}
