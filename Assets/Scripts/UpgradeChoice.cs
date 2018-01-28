using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeChoice : MonoBehaviour {

    public List<Upgrade.Type> Upgrades;
    public GameObject UpgradeRender;

    private List<GameObject> _instanciatedChoices;
    private bool _stopNow = false;
    void Start()
    {
        _instanciatedChoices = new List<GameObject>();
        StartCoroutine(SpawnUpgrades());
    }

    IEnumerator SpawnUpgrades()
    {
        var layoutH = 0f;

        foreach (var up in Upgrades)
        {
            layoutH += UpgradeRender.GetComponent<BoxCollider2D>().size.x;
        }
        Debug.Log("Layout H :: " + layoutH);
        var startSpawn = new Vector2(transform.position.x - layoutH / 3, transform.position.y - 1.5f);
        foreach (var up in Upgrades)
        {
            if (_stopNow)
                break;
            var powerup = Instantiate(UpgradeRender, transform.position, new Quaternion());
            _instanciatedChoices.Add(powerup);
            powerup.transform.parent = this.transform;
            powerup.AddComponent<Upgrade>().SetType(up);
            var travelling = powerup.AddComponent<TravelToTarget>();
            travelling.Target = startSpawn;
            travelling.Speed = 5;
            travelling.AtDestination(pos =>
            {
                powerup.GetComponent<BoxCollider2D>().enabled = true;               
                Debug.Log("Power up OK");
                Debug.Log("Arrived at : " + pos);
            });
            startSpawn.x += UpgradeRender.GetComponent<BoxCollider2D>().size.x;
            yield return new WaitForSeconds(0.4f);
        }
        yield break;
    }

    public void RemoveAllUpgrades()
    {
        _stopNow = true;
        foreach (var powerup in _instanciatedChoices)
        {
            Destroy(powerup);
        }
    }
}
