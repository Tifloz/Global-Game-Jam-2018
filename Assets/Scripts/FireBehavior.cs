using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehavior : MonoBehaviour {

    public float ProjectileDistance { get; set; }
    public float WeaponSize { get; set; }
    public float ProjectileRadius { get; set; }

    public int ProjectileCount { get; set; }

	// Use this for initialization
	void Start () {
        ProjectileDistance = 5;
        WeaponSize = 1;
        ProjectileRadius = 20;
        ProjectileCount = 4;
	}
    #region debug
    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(0.02f, 0.02f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }
    #endregion debug

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0) )
        {
            var camera = Camera.main;
            var pointed = camera.ScreenToWorldPoint(Input.mousePosition);
            pointed.z = 0;
            var thisPos = gameObject.GetComponent<Transform>().position;
            var dir = pointed - thisPos;
            dir.z = 0;
            dir.Normalize();

            var target = thisPos + dir;
            target *= WeaponSize;
            #region debug
            Debug.Log("Draw from " + thisPos + " to " + target);
            DrawLine(thisPos, target, Color.red);
            #endregion debug

        }
    }
}
