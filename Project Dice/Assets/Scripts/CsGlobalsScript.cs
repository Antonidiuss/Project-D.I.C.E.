using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Global
{
    public static int CountOfDices = 4;
    public static int DicesKnown = 0;

}

public class CsGlobals : MonoBehaviour {

	void Start ()
    {
        DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
