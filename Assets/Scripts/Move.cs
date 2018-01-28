using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Move : MonoBehaviour
{
    #region "Variables"
    public float speed;

    public GameObject skeleton;

    private Rigidbody2D _rbody;
    private Animator _anim;
    private Transform _transform;

    private GameObject _anim_face;
    private GameObject _anim_dos;

    #endregion

    private void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _transform = skeleton.GetComponent<Transform>();
        _anim = skeleton.GetComponent<Animator>();

        _anim_face = skeleton.transform.Find("Tronc").gameObject;
        _anim_dos = skeleton.transform.Find("Tronc Dos").gameObject;
    }

    #region "XBox Inputs"

    Vector2 InputXBox()
    {
        var hAxis = Input.GetAxisRaw("Horizontal");
        var vAxis = Input.GetAxisRaw("Vertical");
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
            if (!_anim.GetBool("Up"))
            {
                _anim.SetBool("Up", true);
                SwapRenderers();
            }
        }
        else
        {
            if (_anim.GetBool("Up") && _rbody.velocity.y < 0)
            {
                _anim.SetBool("Up", false);
                SwapRenderers();
            }
            if (_rbody.velocity.x < 0 && _anim.GetBool("left") == false && !_anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                _anim.SetBool("left", true);
                _transform.localScale = new Vector3(-1 * _transform.localScale.x, _transform.localScale.y * 1, _transform.localScale.z * 1);
            }
            else if (_rbody.velocity.x > 0 && _anim.GetBool("left") && !_anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                _anim.SetBool("left", false);
                _transform.localScale = new Vector3(-1 * _transform.localScale.x, _transform.localScale.y * 1, _transform.localScale.z * 1);
            }
        }

    }

    void SwapRenderers()
    {
        if (_anim_dos.gameObject.activeSelf)
        {
            _anim_face.transform.position = _anim_dos.transform.position;
            _anim_dos.SetActive(false);
            _anim_face.SetActive(true);
        }
        else
        {
           _anim_dos.transform.position = _anim_face.transform.position;
           _anim_dos.SetActive(true);
           _anim_face.SetActive(false);
        }
    }
}
