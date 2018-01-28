using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    public GameObject _player;


    private Vector3 _maxScale;
    private Material _mat;
    private PlayerLight _light;
	// Use this for initialization
	void Start ()
	{
	    _maxScale = transform.localScale;
	    _light = _player.GetComponent<PlayerLight>();
	    _mat = GetComponent<UnityEngine.UI.Image>().material;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    transform.localScale = _maxScale * (float)(_light.torchlight / 100);
	}
}
