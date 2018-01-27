using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    #region "Variables"
    public GameObject player;
    public float speed;
    #endregion

    private void Start()
    {
    }

    #region "Keyboard Inputs"
    
    #endregion

    #region "XBox Inputs"

    void InputXBox()
    {
        var hAxis = Input.GetAxis("Horizontal");
        var vAxis = Input.GetAxis("Vertical");
        player.transform.Translate(Vector2.right * speed * hAxis);
        player.transform.Translate(Vector2.up * speed * vAxis);
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
  //      InputKeyboard();
        InputXBox();
    }
}
