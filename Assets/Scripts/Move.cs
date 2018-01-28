using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{
    #region "Variables"
    public float speed;
    private Rigidbody2D _rbody;
    private Animator _anim;
    private Transform _transform;

    #endregion
    private void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
        _transform = GetComponent<Transform>().Find("Skeleton").transform;
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
        _rbody.velocity = velocity * speed;
        if (_rbody.velocity.y > 0)
        {
            _anim.SetBool("Up", true);
        }
        else
        {
            if (_anim.GetBool("Up"))
            {
                _anim.SetBool("Up", false);
            }
            _anim.SetBool("Up", false);
            if (_rbody.velocity.x < 0 && _anim.GetBool("left") == true)
            {
                _anim.SetBool("left", false);
                _transform.localScale = new Vector3(-1 * _transform.localScale.x, _transform.localScale.y * 1, _transform.localScale.y * 1);
            }
            else if (_rbody.velocity.x > 0 && _anim.GetBool("left") == false)
            {
                _transform.localScale = new Vector3(-1 * _transform.localScale.x, _transform.localScale.y * 1, _transform.localScale.y * 1);
                _anim.SetBool("left", true);
            }
        }

    }
}
