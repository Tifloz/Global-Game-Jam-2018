using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{
    public KeyCode[] Keycode_array = new KeyCode[4] {KeyCode.UpArrow, KeyCode.RightArrow,
        KeyCode.DownArrow, KeyCode.LeftArrow} ;
    public float speed = 5;
    private Rigidbody2D rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    #region KeyboardInputs

    Vector2 InputKeyboard()
    {
        int left = 0, right = 0, up = 0, down = 0;

        right = (Input.GetKey(Keycode_array[1])) ? 1 : 0;
        left = (Input.GetKey(Keycode_array[3])) ? -1 : 0;

        up = (Input.GetKey(Keycode_array[0])) ? 1 : 0;
        down = (Input.GetKey(Keycode_array[2])) ? -1 : 0;

        return new Vector2(left + right, up + down);
    }

    #endregion

    #region "XBox Inputs"

    Vector2 InputXBox()
    {
        int left = 0, right = 0, up = 0, down = 0;

        Debug.Log("Input xbox go !");

        right = (Input.GetAxis("Horizontal") > 0.3f) ? 1 : 9;
        left = (Input.GetAxis("Horizontal") < -0.3f) ? -1 : 0;

        up = (Input.GetAxis("Vertical") > 0.3f) ? 1 : 0;
        down = (Input.GetAxis("Vertical") < -0.3f) ? -1 : 0;

        return new Vector2(left + right, up + down);
    }

    #endregion

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 velocity = InputKeyboard();
        if (!Keycode_array.Any(key => Input.GetKey(key)) && Input.GetJoystickNames().Length > 0)
            velocity = InputXBox();
        rbody.velocity = velocity * speed;
    }
}
