using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLight : MonoBehaviour
{
    public double torchlight = 100;
    public double maxtorchlight = 100;
    public double unitToLightRatio = 5;
    public bool inLightSource = false;


    private Rigidbody2D _rbody;

    // Use this for initialization
    void Start ()
    {
        _rbody = GetComponent<Rigidbody2D>();
        StartCoroutine(SlowLightLoss());
    }


    IEnumerator SlowLightLoss()
    {
        while (torchlight > 0)
        {
            if (!inLightSource)
            {
                Vector2 prev_position = _rbody.position;
                yield return new WaitForSeconds(.2f);
                Vector2 new_position = _rbody.position;
                var distance = Math.Sqrt(Math.Pow(new_position.x - prev_position.x, 2) +
                                         Math.Pow(new_position.y - prev_position.y, 2));
                torchlight -= (distance / unitToLightRatio);
            }
            else
                yield return new WaitForSeconds(.2f);
        }
        if (torchlight <= 0)
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 200, 200), "Player Heatlh == " + torchlight);
    }
}
