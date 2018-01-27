using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightCollider : MonoBehaviour
{

    private Light _light;
    private CircleCollider2D _box;

    // Use this for initialization
    void Start()
    {
        _light = GetComponent<Light>();
        _box = GetComponent<CircleCollider2D>();
        _box.radius = _light.range / (float)12.5;
    }
}
