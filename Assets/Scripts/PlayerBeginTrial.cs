using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeginTrial : TriggerPlayerAction
{
    public GameObject RewardItem;
    public List<Vector2> TargetPosition;

    private bool start;

    void Start()
    {
        start = false;
    }

    private IEnumerator SpawnObjectives(GameObject player)
    {
        Activate(true);
        foreach (var p in TargetPosition)
        {
            var item = Instantiate(RewardItem);
            Destroy(item.GetComponent<CircleCollider2D>());
            var t = item.AddComponent<TravelToTarget>();
            t.transform.position = transform.localPosition;
            t.Target = new Vector2(transform.localPosition.x, transform.localPosition.y) + p;
            t.Speed = 10;
            t.AtDestination(pos => {
                var collider = item.AddComponent<CircleCollider2D>();
                collider.isTrigger = true;
                item.AddComponent<TrialPickup>();
            });
            yield return new WaitForSeconds(0.4f);
        }
        var collector = player.AddComponent<TrialPickupCollector>();
        collector.PickupGoal = TargetPosition.Count;
        gameObject.AddComponent<PlayerCompleteTrial>();
        collector.Spawner = this.gameObject;
        Destroy(this);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player" && !start)
        {
            start = true;
            OnActionTrigger(collider2D.gameObject);
        }
    }

    protected override void OnActionTrigger(GameObject player)
    {

        StartCoroutine(SpawnObjectives(player));
    }
}