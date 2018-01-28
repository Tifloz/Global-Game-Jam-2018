using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public float blink_speed;
    private Light Light;
    private int Number = 1;
    private System.Random random = new System.Random();
    private int i = 0;

    private int RandomNumber(int min, int max)
    {
        int t = random.Next(min, max + 1);
        return t;
    }
    // Use this for initialization
    void Start()
    {
        Light = GetComponentInChildren<Light>();
        Number = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Number == 0 && i < 8)
        {
            Light.range -= 0.8f;
            StartCoroutine(Switch_on());
        }
        if (Number == 1 && i < 8)
        {
            Light.range -= 1;
            StartCoroutine(Switch_off());
        }
        if (i >= 8)
            i = 0;
    }
    IEnumerator Switch_off()
    {
        yield return new WaitForSeconds(RandomNumber(1, 2) / blink_speed);
        Number = 0;
        i++;
    }
    IEnumerator Switch_on()
    {
        yield return new WaitForSeconds(RandomNumber(1, 2) / blink_speed);
        Number = 1;
        i++;
    }
   
}
