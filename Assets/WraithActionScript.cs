using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework.Constraints;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class WraithActionScript : MonoBehaviour
{
    public bool attacking = false;
    public float _stalkRange = 2;
    public float health = 100;
    public float speed = 1;
    public float rotate_speed = 1;
    public float damage;

    private bool burning = false;
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
            speed /= 1.5f;
            burning = true;
            StartCoroutine(GetBurnt(other));
        }
        else if (other.tag == "Player")
        {
            StartCoroutine(DamagePlayer());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerLight")
        {
            burning = false;
            speed *= 1.5f;
        }
        else if (other.tag == "Player")
        {
            StopCoroutine("DamagePlayer");
        }
    }

    IEnumerator GetBurnt(Collider2D other)
    {
        var light = other.gameObject.GetComponent<lightCollider>();
        while (burning)
        {
            health -= light.damage;
            yield return new WaitForSeconds(.2f);
            if (health <= 0)
                Destroy(gameObject);
        }
    }

    IEnumerator DamagePlayer()
    {
        var player = _player.GetComponent<PlayerLight>();
        while (true)
        {
            player.torchlight -= damage;
            yield return new WaitForSeconds(.2f);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(00, 200, 200, 200), "Wraith Heatlh == " + health);
    }
}
