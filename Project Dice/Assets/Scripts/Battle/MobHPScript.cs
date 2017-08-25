using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobHPScript : MonoBehaviour
{

    public int HP, curHP, deathHP;
    public GameObject mob;
    public Texture2D HPTex;
    public bool chossen = false;

    public int damage;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            chossen = true;
        }
        if (curHP <= deathHP)
        {
            Destroy(gameObject);
        }
    }

    void OnGUI()
    {
        Vector2 posScr = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        GUI.Box(new Rect(posScr.x+460, Screen.height - posScr.y-230, 100, 5), " ");
        GUI.DrawTexture(new Rect(posScr.x+460, Screen.height - posScr.y-230, curHP, 5), HPTex);
    }

    void attack()
    {

    }
}
