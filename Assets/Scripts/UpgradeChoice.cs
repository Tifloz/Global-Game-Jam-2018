using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.WSA;

public class UpgradeChoice : MonoBehaviour {

    public List<Upgrade.Type> Upgrades;
    public GameObject UpgradeRender;
    public GameObject Village;
    public GameObject Player;

    private List<GameObject> _instanciatedChoices = new List<GameObject>();
    private bool _stopNow = false;

    void Start()
    {
    }

    public void LaunchUpgrades()
    {
        StartCoroutine(SpawnUpgrades());
    }

    IEnumerator SpawnUpgrades()
    {
        var layoutH = 0f;

        foreach (var up in Upgrades)
        {
            layoutH += UpgradeRender.GetComponent<BoxCollider2D>().size.x;
        }
        var startSpawn = new Vector2(transform.position.x - layoutH / 1.3f, transform.position.y - 3.5f);
        foreach (var up in Upgrades)
        {
            if (_stopNow)
                break;
            var powerup = Instantiate(UpgradeRender, transform.position, new Quaternion());
            powerup.transform.parent = this.transform;
            powerup.AddComponent<Upgrade>().SetType(up);
            var travelling = powerup.AddComponent<TravelToTarget>();
            travelling.Target = startSpawn;
            travelling.Speed = 5;
            travelling.AtDestination(pos =>
            {
                powerup.GetComponent<BoxCollider2D>().enabled = true;
            });
            startSpawn.x += UpgradeRender.GetComponent<BoxCollider2D>().size.x * 2;
            _instanciatedChoices.Add(powerup);
            yield return new WaitForSeconds(0.4f);
        }
    }

    public void RemoveAllUpgrades()
    {
        _stopNow = true;
        Village.transform.Find("Spotlight").gameObject.SetActive(true);
        Destroy(gameObject.transform.Find("Light"));
        var torchlight =Player.GetComponent<PlayerLight>();
        StartCoroutine(UpLight(torchlight));
        foreach (var powerup in _instanciatedChoices)
        {
            Destroy(powerup);
        }
    }

    IEnumerator UpLight(PlayerLight light)
    {
        var heal = light.maxtorchlight - light.torchlight;
        while (heal > 0)
        {
            heal -= 1f;
            light.torchlight += 1f;
            yield return new WaitForSeconds(.2f);

        }
    }
}
