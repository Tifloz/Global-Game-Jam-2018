using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBonus : MonoBehaviour {

    public GameObject Gem;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Mana>().PickUpGem();
            Destroy(Gem);
        }
    }
}
