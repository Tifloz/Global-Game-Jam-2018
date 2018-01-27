using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHeal : MonoBehaviour
{
    public float recovery_speed = 0.1f;
    public float health = 100;
    public float maxhealth = 100;
    public float recov_frame_time = 0.05f;

    private PlayerLight player;
    private bool _healing = false;
	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(RecoverHealth());
	}
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator RecoverHealth()
    {
        while (true)
        {
            health += recovery_speed;
            if (health > maxhealth)
                health = maxhealth;
            yield return new WaitForSeconds(.4f);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerLight>().inLightSource = true;
            player = other.GetComponent<PlayerLight>();
            _healing = true;
            StartCoroutine(HealPlayer());
        }
    }

    IEnumerator HealPlayer()
    {
        while (_healing)
        {
            if (player.torchlight < player.maxtorchlight)
            {
                var healvalue = health - recovery_speed;
                if (health < 0)
                {
                    healvalue += health;
                    health = 0;
                }
                player.torchlight += recovery_speed;
                if (player.torchlight > player.maxtorchlight)
                    player.torchlight = player.maxtorchlight;
                yield return new WaitForSeconds(recov_frame_time);
            }
            else
                yield return new WaitForSeconds(recov_frame_time);
        }
    }



    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerLight>().inLightSource = false;
            _healing = false;
        }
    }
}
