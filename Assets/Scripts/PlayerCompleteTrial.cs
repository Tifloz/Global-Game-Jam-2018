using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCompleteTrial : TriggerPlayerAction {
    protected override void OnActionTrigger(GameObject player)
    {
        var collector = player.GetComponent<TrialPickupCollector>();
        if (collector.Completed())
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.GetComponent<UpgradeChoice>().enabled = true;
            Destroy(collector);
            Destroy(this);
        }
    }
}
