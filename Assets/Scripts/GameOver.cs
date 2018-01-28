using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
public Text text;
    private int cmpt = 5;
	// Use this for initialization
	void Start () {
		StartCoroutine(Counter());
	}
  IEnumerator Counter()
    {
        while (cmpt > 0)
        {
            text.text = cmpt.ToString();
            cmpt--;
                yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

   public void Loader()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void Restart()
    {
        SceneManager.LoadScene("FloScene", LoadSceneMode.Single);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
