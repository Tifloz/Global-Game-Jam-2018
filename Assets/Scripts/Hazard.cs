using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {
   // public GameObject playerScript;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("I'm here");
        if (this.gameObject.tag == "Pluie")
        {
            StartCoroutine(Take_Damage(1));
        }
        if (this.gameObject.tag == "Vent")
        {
            StartCoroutine(Take_Damage(2));
        }
        if (this.gameObject.tag == "Neige")
        {
            StartCoroutine(Take_Damage(3));
        }
    }

    IEnumerator Take_Damage(int type)
    {
        yield return new WaitForSeconds(1);
        if (type == 1)
        {
            Debug.Log("Pluie");
        }
        if (type == 2)
        {
            Debug.Log("vent");
        }
        if (type == 3)
        {
            Debug.Log("Neige");
        }
    }
}
