using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTiling : MonoBehaviour
{

    public GameObject TileSprite;
	// Use this for initialization
	void Start ()
	{
	    var spritesize = TileSprite.GetComponent<SpriteRenderer>().size;
	    var end = new Vector3(500, -500, 0);
	    var current = transform.localPosition;
	    while (end.y < current.y)
	    {
	        while (current.x < end.x)
	        {
	            var thingy = Instantiate(TileSprite, transform);
	            thingy.transform.position = current;
	            current.x += spritesize.x;
	        }
	        current.x = -500;
	        current.y -= spritesize.y;
	    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
