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
    public GameObject Pluie;
    public GameObject Neige;
    public GameObject Vent;
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
        Destroy(_curr_prefab);
        exist = false;
    }

    void Select_type(int type)
    {
        if (type == 1)
        {
            _curr_prefab = Instantiate(Pluie,Rain[RandomNumber(0,Rain.Length -1)].transform.position, Quaternion.identity);
        }
        if (type == 2)
        {
            _curr_prefab = Instantiate(Vent, Wind[RandomNumber(0, Wind.Length -1)].transform.position, Quaternion.identity);
        }
        if (type == 3)
        {
            _curr_prefab = Instantiate(Neige, Snow[RandomNumber(0, Snow.Length -1)].transform.position, Quaternion.identity);
        }
        StartCoroutine(Zone_Duration(_curr_prefab));
    }
    // Update is called once per frame
    void Update()
    {
        if (exist == false)
        {
            exist = true;
            Select_type(RandomNumber(1, 3));    
        }
    }
}
