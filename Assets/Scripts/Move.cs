using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    #region "Variables"
    public GameObject player;
    public KeyCode[] Keycode_array = new KeyCode[6];
    public float speed;
    #endregion

    #region "Keyboard Inputs"

    void InputKeyboard()
    {
        if (Input.GetKey(Keycode_array[0]))
        {
            player.transform.Translate(Vector2.up * speed);
        }

        if (Input.GetKey(Keycode_array[1]))
        {
            player.transform.Translate(Vector2.right * speed);
        }

        if (Input.GetKey(Keycode_array[2]))
        {
            player.transform.Translate(Vector2.down * speed);
        }

        if (Input.GetKey(Keycode_array[3]))
        {
            player.transform.Translate(Vector2.left * speed);
        }
    }

    #endregion

    #region "XBox Inputs"

    void InputXBox()
    {
        if (Input.GetAxis("Horizontal") > 0.3)
        {
            player.transform.Translate(Vector2.right * speed);
        }
        if (Input.GetAxis("Horizontal") < 0.3)
        {
            player.transform.Translate(Vector2.left * speed);
        }
        if (Input.GetAxis("Vertical") > 0.3)
        {
            player.transform.Translate(Vector2.up * speed);
        }
        if (Input.GetAxis("Vertical") < 0.3)
        {
            player.transform.Translate(Vector2.down * speed);
        }
    }

    #endregion
    // Update is called once per frame
    void Update () {
        InputKeyboard();
        InputXBox();
	}
}
