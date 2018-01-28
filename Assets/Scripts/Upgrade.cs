using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : TriggerPlayerAction {

    public enum Type
    {
        e_Damage,
        e_Distance,
        e_RateOfFire,
        e_Count
    }

    public Type UpgradeType;

    public void SetType(Type type)
    {
        var light = GetComponent<Light>();
        switch (type)
        {
            case Type.e_Damage:
                light.color = Color.red; break;
            case Type.e_RateOfFire:
                light.color = Color.yellow; break;
            case Type.e_Distance:
                light.color = Color.green; break;
            case Type.e_Count:
                light.color = Color.white; break;
        }
        UpgradeType = type;
    }

    protected override void OnActionTrigger(GameObject player)
    {
        Activate(true);
        Debug.Log("Upgrade!");
        switch (UpgradeType)
        {
            case Type.e_Damage:
                {
                    break;
                }
            case Type.e_Count:
                {
                    player.GetComponent<FireBehavior>().ProjectileCount += 1;
                    break;
                }
            case Type.e_RateOfFire:
                {
                    player.GetComponent<FireBehavior>().RateOfFire -= 0.07f;
                    break;
                }
            case Type.e_Distance:
                {
                    player.GetComponent<FireBehavior>().projectileDistance += 4;
                    break;
                }
        }
        GetComponentInParent<UpgradeChoice>().RemoveAllUpgrades();
    }

}
