using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WarningTextScript : MonoBehaviour {
    Color color;
    
    private void Awake()
    {

    }
    // Use this for initialization
    void Start () {
        color = GetComponent<Text>().color;
    }
	
	// Update is called once per frame
	void Update () {
        color.a -= 0.01f;
        GetComponent<Text>().color = color;
    }

    public void NewMessage(string str)
    {
        color.a = 1;
        GetComponent<Text>().text = str;
    }
}