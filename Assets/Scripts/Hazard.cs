using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float seconds = 1;
    private PlayerLight player;
    private bool into = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.GetComponent<PlayerLight>();
            into = true;
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
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        into = false;
    }
    IEnumerator Take_Damage(int type)
    {
        while (into)
        {
            if (type == 1)
            {
                player.torchlight -= 0.5f;
            }
            if (type == 2)
            {
                player.torchlight -= 1;
            }
            if (type == 3)
            {
                player.torchlight -= 0.25f;
            }
            yield return new WaitForSeconds(seconds);
        }
    }

}
