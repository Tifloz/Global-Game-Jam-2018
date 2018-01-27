using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* On doit créer des tags selon la zone voulue
 * - Pluie
 * - Vent
 * 
 * 
 */
public class HazardManager : MonoBehaviour
{
    private GameObject[] Rain;
    private GameObject[] Snow;
    private GameObject[] Wind;
    private GameObject _curr_prefab;
    private System.Random random = new System.Random();
    private bool exist = false;

    private int RandomNumber(int min, int max)
    {
        int t = random.Next(min, max + 1);
        return t;
    }
    // Use this for initialization
    void Start()
    {
        Rain = GameObject.FindGameObjectsWithTag("Pluie");
        Wind = GameObject.FindGameObjectsWithTag("Vent");
        Snow = GameObject.FindGameObjectsWithTag("Neige");
    }

    IEnumerator Zone_Duration(GameObject _curr_prefab)
    {
        yield return new WaitForSeconds(RandomNumber(30, 50));
        _curr_prefab.SetActive(false);
        exist = false;
    }

    void Select_type(int type)
    {
        exist = true;
        if (type == 1)
        {
            _curr_prefab = Rain[RandomNumber(0, Rain.Length - 1)];
            _curr_prefab.SetActive(true);
        }
        if (type == 2)
        {
            _curr_prefab = Wind[RandomNumber(0, Wind.Length - 1)];
            _curr_prefab.SetActive(true);
        }
        if (type == 3)
        {
            _curr_prefab = Snow[RandomNumber(0, Snow.Length - 1)];
            _curr_prefab.SetActive(true);
        }
        StartCoroutine(Zone_Duration(_curr_prefab));
    }
    // Update is called once per frame
    void Update()
    {
        if (exist == false)
        {
            Select_type(RandomNumber(1, 3));
        }
    }
}
