using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour {
    private new Light light;

	// Use this for initialization
	void Start () {
        light = GetComponentInChildren<Light>();
        light.intensity = 0;
	}

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Lul");
        if (collision.tag == "Player" && light.intensity == 0)
            light.intensity = 3;
    }
}
