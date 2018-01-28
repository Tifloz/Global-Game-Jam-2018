using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehavior : MonoBehaviour {

    #region "Variables"
    public GameObject projectile;
    public float projectileDistance;
    public float WeaponSize;
    public float ProjectileRadius;
    public float ShotRadius;
    private Animator _anim;
    public int ProjectileCount;
 
    #endregion "Variables"
    // Use this for initialization
    void Start () {
        _anim = GetComponentInChildren<Animator>();
    }

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

            if (Input.GetButton("Fire1"))
            {
                Debug.Log(dir);
                if (dir.y >= 0.7)
                    _anim.SetBool("Attackup", true);
                else
                    _anim.SetBool("Attack", true);
            }

            var target = thisPos + dir;
            target *= WeaponSize;
            #region debug
            Debug.Log("Draw from " + thisPos + " to " + target);
            Debug.DrawLine(thisPos, target, Color.red, 0.2f);
            #endregion debug

            /// Creating Projectile
            for (int i = 0; i < ProjectileCount; ++i)
            {
                var pr = Instantiate(projectile, target, Quaternion.identity);
                pr.GetComponent<Transform>().localScale *= ProjectileRadius;
                /// Getting bounds of direction
                /// 
                var randomAngle = RandomFromDistribution.RandomRangeNormalDistribution(-ShotRadius, ShotRadius, RandomFromDistribution.ConfidenceLevel_e._999);
                Vector3 v2 = Quaternion.AngleAxis(randomAngle, Vector3.forward) * dir;
                pr.GetComponent<Rigidbody2D>().AddForce(v2 * (5.0f * Random.Range(0.3f, 0.7f)), ForceMode2D.Impulse);
                Destroy(pr, 1);
            }
        }
        else
        {
            _anim.SetBool("Attack", false);
            _anim.SetBool("AttackUp", false);
        }
    }
}
