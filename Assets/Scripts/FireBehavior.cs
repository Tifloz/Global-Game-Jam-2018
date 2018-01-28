using UnityEngine;

public class FireBehavior : MonoBehaviour {


    public GameObject projectile;
    public float WeaponSize;
    public float ProjectileRadius;
    public float RateOfFire;
    public float ProjectileVelocityAvg;
    public int ProjectileCount;
    public float ProjVelocityRange;
    public GameObject skeleton;

    private Animator _anim;
    private float _interval;
    private Camera _camera;
    private Rigidbody2D _rbody;
    private PlayerLight _plight;
    private Transform _transform;
    private GameObject _anim_face;
    private GameObject _anim_dos;
    // Use this for initialization
    void Start () {
        _anim = GetComponentInChildren<Animator>();
        _interval = 0f;
        _camera = Camera.main;
        _rbody = GetComponent<Rigidbody2D>();
        _plight = GetComponent<PlayerLight>();
        _transform = skeleton.GetComponent<Transform>();
        _anim_face = skeleton.transform.Find("Tronc").gameObject;
        _anim_dos = skeleton.transform.Find("Tronc Dos").gameObject;
    }

    // Update is called once per frame
    void Update () {
        if (_interval >= RateOfFire)
        {
            if (Input.GetButton("Fire1"))
            {
                var pointed = _camera.ScreenPointToRay(Input.mousePosition).origin;
                pointed.z = 0;
                var thisPos = transform.position;
                var dir = pointed - thisPos;
                dir.z = 0;
                dir.Normalize();

                SetFirePosition(dir);

                var target = thisPos + dir * WeaponSize;

                /// Creating Projectile
                for (int i = 0; i < ProjectileCount; ++i)
                {
                    var pr = Instantiate(projectile, target, Quaternion.identity);
                    pr.GetComponent<Transform>().localScale *= ProjectileRadius;
                    /// Getting bounds of direction
                    /// 
                    var randomAngle =
                        RandomFromDistribution.RandomRangeNormalDistribution(-30, 30,
                            RandomFromDistribution.ConfidenceLevel_e._999);

                    //Debug.Log("Random angle == " + randomAngle);
                    //Debug.Log("Angle Axi == " + Quaternion.AngleAxis(randomAngle, Vector3.forward));
                    Vector2 v2 = Quaternion.AngleAxis(randomAngle, Vector3.forward) * dir;
                    //Debug.Log("V2 == " + v2);

                    pr.GetComponent<Rigidbody2D>()
                        .AddForce(
                            v2 * (Random.Range(ProjectileVelocityAvg - ProjVelocityRange,
                                ProjectileVelocityAvg + ProjVelocityRange)) + _rbody.velocity, ForceMode2D.Impulse);
                    Destroy(pr, 1);
                }
                _interval = 0;
                _plight.torchlight -= 0.9;
            }
        }
        else
        {
            _anim.SetBool("Attack", false);
            _anim.SetBool("AttackUp", false);
            _interval += Time.deltaTime;
        }
    }

    void SetFirePosition(Vector2 dir)
    {
        if (dir.y >= 0.7)
        {
            _anim.SetBool("AttackUp", true);
            if (_anim.GetBool("Up") == false)
            {
                SwapRenderers();
                _anim.SetBool("Up", true);
            }
        }
        else
        {
            if (_anim.GetBool("Up"))
            {
                SwapRenderers();
                _anim.SetBool("Up", false);
            }
            if (dir.x > 0 && _anim.GetBool("left"))
            {
                _anim.SetBool("left", false);
                _transform.localScale = new Vector3(-1 * _transform.localScale.x, _transform.localScale.y * 1, _transform.localScale.z * 1);
            }
            else if (dir.x < 0 && _anim.GetBool("left") == false)
            {
                _anim.SetBool("left", true);
                _transform.localScale = new Vector3(-1 * _transform.localScale.x, _transform.localScale.y * 1, _transform.localScale.z * 1);
            }
            _anim.SetBool("Attack", true);
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

