using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}

    public void Load_Scene(string str)
    {
        SceneManager.LoadScene(str, LoadSceneMode.Single);
    }
	public void Quitter()
    {
       Application.Quit();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
