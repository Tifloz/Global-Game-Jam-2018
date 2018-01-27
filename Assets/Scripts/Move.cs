using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{
    #region "Variables"
    public GameObject player;
    public float speed;
    private Rigidbody2D rbody;
    #endregion
    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    #region "XBox Inputs"

    Vector2 InputXBox()
    {
        var hAxis = Input.GetAxis("Horizontal");
        var vAxis = Input.GetAxis("Vertical");
        var moveV = Vector2.right * hAxis;
        var moveH = Vector2.up * vAxis;
        return moveV + moveH;
    }

    #endregion

    // Update is called once per frame
    void FixedUpdate()
    {
        var velocity = InputXBox();
        rbody.velocity = velocity * speed;
    }
}
