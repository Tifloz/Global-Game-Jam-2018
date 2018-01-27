using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour {

    public int ManaMax = 0;
    public int ManaCurrent = 0;
	// Use this for initialization

    public void PickUpGem()
    {
        Debug.Log("PickUp Gem");
        ManaMax += 1;
        ManaCurrent = ManaMax;
    }

}
