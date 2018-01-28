using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRend : MonoBehaviour {
    public AudioClip source;
    private AudioSource bruh;
	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bruh = collision.GetComponent<AudioSource>();
            bruh.clip = source;
            if (!bruh.isPlaying)
            {
                bruh.Play();
                bruh.volume = 0.5f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            StartCoroutine(Counter());
    }
    IEnumerator Counter()
    {
        while (bruh.volume >= 0)
        {
            bruh.volume = -0.15f;
            yield return new WaitForSeconds(1);
        }
        if (bruh.volume <= 0)
            bruh.Stop();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
