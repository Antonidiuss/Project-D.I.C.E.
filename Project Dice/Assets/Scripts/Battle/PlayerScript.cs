using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int HP;
    public Text HPStatus;

    void Start () {
		
	}


    void Update()
    {
        HPStatus.text = System.Convert.ToString(HP);
    }
}