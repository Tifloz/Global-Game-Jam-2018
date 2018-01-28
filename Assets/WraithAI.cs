using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class WraithAI : MonoBehaviour
{

    public float minWait = 5;
    public float maxWait = 45;

    public float squadPossibility = 0;

    enum WraithBehaviour
    {
        ERROR = -1,
        LONE = 0,
        SQUADMEN = 1,
        SQUADCHIEF = 2
    }

    private GameObject[] _squad;
    private GameObject _player;
    private WraithBehaviour _behaviour = WraithBehaviour.ERROR;
    private float attackWaitTimer = float.MaxValue;

    private WraithActionScript _action;

	void Start ()
	{
	    _action = GetComponent<WraithActionScript>();
		_player = GameObject.FindWithTag("Player");
	    initBehaviour();
	}

    void initBehaviour()
    {
        var nb = Random.Range(1, 100);
        if (nb <= squadPossibility)
        {
            if (GameObject.FindGameObjectWithTag("SquadChief") == null)
                initSquadChiefWraith();
            else
                initSquadMenWraith();
        }
        else
            initLoneWraith();
    }

    void initSquadMenWraith()
    {
        tag = "SquadMan";
        _behaviour = WraithBehaviour.SQUADMEN;
        StartCoroutine(SquadMenLoop());
    }

    void initSquadChiefWraith()
    {
        tag = "SquadChief";
        _behaviour = WraithBehaviour.SQUADCHIEF;
        attackWaitTimer = Random.Range(minWait, maxWait);
        StartCoroutine(SquadChiefLoop());
    }

    void initLoneWraith()
    {
        tag = "LoneWolf";
        _behaviour = WraithBehaviour.LONE;
        attackWaitTimer = Random.Range(minWait, maxWait);
        StartCoroutine(LoneWraithLoop());
    }

    IEnumerator LoneWraithLoop()
    {
        yield return new WaitForSeconds(attackWaitTimer);
        _action.LoneWolfAttack();
    }

    bool readyToAttack()
    {
        return _action.attacking;
    }

    IEnumerator SquadMenLoop()
    {
        yield return new WaitUntil(readyToAttack);
        tag = "LoneWolf";
        _action.LoneWolfAttack();
    }

    IEnumerator SquadChiefLoop()
    {
        yield return new WaitForSeconds(attackWaitTimer);
        _squad = GameObject.FindGameObjectsWithTag("SquadMan");
        foreach (var unit in _squad)
        {
            yield return new WaitForSeconds(Random.Range(0.0f, 0.5f));
            unit.GetComponent<WraithActionScript>().attacking = true;
        }
        tag = "LoneWolf";
        _action.LoneWolfAttack();
    }

}
