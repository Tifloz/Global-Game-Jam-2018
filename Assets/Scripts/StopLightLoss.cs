using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLightLoss : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.Find("Spawner").gameObject.SetActive(false);
            other.GetComponent<PlayerLight>().inLightSource = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.Find("Spawner").gameObject.SetActive(true);
            other.GetComponent<PlayerLight>().inLightSource = false;
        }
    }
}
