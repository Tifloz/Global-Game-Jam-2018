using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehavior : MonoBehaviour {

    #region "Variables"
    public GameObject projectile;
    public float projectileDistance;
    public float WeaponSize;
    public float ProjectileRadius;
    public float RateOfFire;
    public float ProjectileVelocityAvg;
    public int ProjectileCount;

    private float _interval;

    #endregion "Variables"
    // Use this for initialization
    void Start () {
        _interval = 0f;
    }

    // Update is called once per frame
    void Update () {

        if (_interval == RateOfFire)
        {
            if (Input.GetButton("Fire1"))
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
                Debug.DrawLine(thisPos, target, Color.red, 0.2f);
                #endregion debug

                /// Creating Projectile
                Debug.Log("Normal direction: " + dir);
                for (int i = 0; i < ProjectileCount; ++i)
                {
                    var pr = Instantiate(projectile, target, Quaternion.identity);
                    pr.GetComponent<Transform>().localScale *= ProjectileRadius;
                    /// Getting bounds of direction
                    /// 
                    var randomAngle = RandomFromDistribution.RandomRangeNormalDistribution(-30, 30, RandomFromDistribution.ConfidenceLevel_e._999);
                    Vector3 v2 = Quaternion.AngleAxis(randomAngle, Vector3.forward) * dir;
                    Debug.Log("Projectile direction: " + v2);
                    Debug.Log("random = " + randomAngle);
                    pr.GetComponent<Rigidbody2D>().AddForce(v2 * (5.0f * Random.Range(ProjectileVelocityAvg - 0.2f, ProjectileVelocityAvg + 0.2f)), ForceMode2D.Impulse);
                    Destroy(pr, 1);
                }
                _interval = 0;
            }
        }
        else
        {
            _interval += Time.deltaTime;
            if (_interval > RateOfFire)
                _interval = RateOfFire;
        }

    }
}
