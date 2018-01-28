using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichRendererFace : MonoBehaviour {

    // Use this for initialization
    private Animator _anim;
    private bool check;
    void Start () {
        _anim = transform.parent.GetComponent<Animator>();
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_anim.GetBool("Up") && check == false)
        {
            check = true;
            Renderer[] rs = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs)
                r.enabled = false;
        }
        if (_anim.GetBool("Up") == false)
        {
            check = false;
            Renderer[] rs = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs)
                r.enabled = true;
        }
    }
}
