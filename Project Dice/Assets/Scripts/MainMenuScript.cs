using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 50, 50), "Start"))
        {
            print("Start Game");
            Application.LoadLevel("Battle Scene");
        }

        if (GUI.Button(new Rect(10, 80, 50, 50), "Exit"))
        {
            print("Exit Game");
            Application.Quit();
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
