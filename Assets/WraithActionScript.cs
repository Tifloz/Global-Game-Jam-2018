using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class WraithActionScript : MonoBehaviour
{
    public bool attacking = false;
    public float _stalkRange = 2;
    public float health = 100;
    public float speed = 1;
    public float rotate_speed = 1;


    private bool _collidingPlayer;
    private GameObject _player;
    private Rigidbody2D _pbody;
    private Rigidbody2D _body;


	void Start () {
		_player = GameObject.FindWithTag("Player");
	    _pbody = _player.GetComponent<Rigidbody2D>();
	    _body = GetComponent<Rigidbody2D>();
	    if (UnityEngine.Random.Range(0, 1) != 1)
	        rotate_speed = -rotate_speed;
	}

	void FixedUpdate()
	{
        if (!attacking)
            OrbitPlayer();
	}

    float GetDistance(Vector3 origin, Vector3 other)
    {
        return (float)Math.Sqrt(Math.Pow(origin.x - other.x, 2) + Math.Pow(origin.y - other.y, 2));
    }

    void OrbitPlayer()
    {
        var distance = GetDistance(_player.transform.position, transform.position);
        var target_pos = _player.transform.position;
        if (distance > _stalkRange)
        {
            var future_pos = new Vector2(target_pos.x, target_pos.y) + _pbody.velocity;
            _body.velocity = (new Vector2(transform.position.x, transform.position.y) - future_pos).normalized * -speed;

        }
        else if (distance <= _stalkRange)
        {
            transform.RotateAround(target_pos, new Vector3(0, 0, 1), rotate_speed);
            transform.rotation = new Quaternion();
        }

    }

    public void LoneWolfAttack()
    {
        attacking = true;
        StartCoroutine(LoneWolfRoutine());
    }

    IEnumerator LoneWolfRoutine()
    {
        while (true)
        {
            _body.velocity = (transform.position - _player.transform.position).normalized * -speed;
            yield return new WaitForSeconds(.3f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerLight")
        {
            StartCoroutine(TakeLightDamage());
        }
    }


    void On

}
