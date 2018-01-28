using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCompleteTrial : TriggerPlayerAction {
    protected override void OnActionTrigger(GameObject player)
    {
        var collector = player.GetComponent<TrialPickupCollector>();
        if (collector.Completed())
        {
            gameObject.AddComponent<StopLightLoss>();
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.GetComponent<UpgradeChoice>().enabled = true;
            player.GetComponent<PlayerLight>().inLightSource = true;
            Destroy(collector);
            Destroy(this);
        }
    }
}
