using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackScript : MonoBehaviour {

    public Text TotalNumber;
    public Button btn;

    public bool d1WasAdded = false;
    public bool d2WasAdded = false;
    public bool d3WasAdded = false;
    public bool d4WasAdded = false;

    public Text d1, d2, d3, d4, total;
    public WhatADice Dice1, Dice2, Dice3, Dice4;

    private MobHPScript mob;
    private PlayerScript player;

    private int HowManyDicesKnown = 0;
    private int totalDamage = 0;

    void Start () {
        btn.onClick.AddListener(Click);

        Dice1 = GameObject.Find("Dice1Btn").GetComponent<WhatADice>();
        Dice2 = GameObject.Find("Dice2Btn").GetComponent<WhatADice>();
        Dice3 = GameObject.Find("Dice3Btn").GetComponent<WhatADice>();
        Dice4 = GameObject.Find("Dice4Btn").GetComponent<WhatADice>();

        mob = GameObject.Find("Mob-1").GetComponent<MobHPScript>();
        player = GameObject.Find("Player").GetComponent<PlayerScript>();


    }

    public void ChangeTotalAttack(int number)
    {
        totalDamage = number;
    }

    void Update () {

        total.text = System.Convert.ToString(totalDamage);

        if (Dice1.whatadice == true & d1WasAdded == false)
        {
            HowManyDicesKnown++;
            totalDamage = System.Convert.ToInt32(d1.text) + totalDamage;
            d1WasAdded = true;
        }
        if (Dice2.whatadice == true & d2WasAdded == false)
        {
            HowManyDicesKnown++;
            totalDamage = System.Convert.ToInt32(d2.text) + totalDamage;
            d2WasAdded = true;
        }
        if (Dice3.whatadice == true & d3WasAdded == false)
        {
            HowManyDicesKnown++;
            totalDamage = System.Convert.ToInt32(d3.text) + totalDamage;
            d3WasAdded = true;
        }
        if (Dice4.whatadice == true & d4WasAdded == false)
        {
            HowManyDicesKnown++;
            totalDamage = System.Convert.ToInt32(d4.text) + totalDamage;
            d4WasAdded = true;
        }

        if (HowManyDicesKnown == 4)
        {
            GameObject.Find("Dice1Btn").GetComponent<WhatADice>().EndPhase();
            GameObject.Find("Dice2Btn").GetComponent<WhatADice>().EndPhase();
            GameObject.Find("Dice3Btn").GetComponent<WhatADice>().EndPhase();
            GameObject.Find("Dice4Btn").GetComponent<WhatADice>().EndPhase();
            d1WasAdded = false;
            d2WasAdded = false;
            d3WasAdded = false;
            d4WasAdded = false;
            HowManyDicesKnown = 0;
        }
    }

    public void EndPhase()
    {

    }

    public void EndTurn()
    {
        Click();
    }

    void Click()
    {



        mob.curHP = mob.curHP - totalDamage;
        player.HP = player.HP - mob.damage;

        ZeroingOut();


    }

    void ZeroingOut()
    {
        totalDamage = 0;
        HowManyDicesKnown = 0;

        Dice1.ChangeAttack(0);
        Dice2.ChangeAttack(0);
        Dice3.ChangeAttack(0);
        Dice4.ChangeAttack(0);

        Dice1.whatadice = false;
        Dice2.whatadice = false;
        Dice3.whatadice = false;
        Dice4.whatadice = false;

        d1WasAdded = false;
        d2WasAdded = false;
        d3WasAdded = false;
        d4WasAdded = false;
    }
}





/*
 * 
 *         if (Dice1.whatadice == true & d1WasAdded == false)
        {
            if (d2.text == d1.text & d3.text == d1.text & d4.text == d1.text & HowManyDicesKnown == 3)
            {
                HowManyDicesKnown++;
                Dice1.Warning("X4 DICES!!!");
                totalDamage = System.Convert.ToInt32(d1.text)*4 + totalDamage;
                d1WasAdded = true;
            }
            else if (d2.text == d1.text & d3.text == d1.text & HowManyDicesKnown == 2 | d3.text == d1.text & d4.text == d1.text & HowManyDicesKnown == 2 | d4.text == d1.text & d2.text == d1.text & HowManyDicesKnown == 2)
            {
                HowManyDicesKnown++;
                Dice1.Warning("X3 dices!");
                totalDamage = System.Convert.ToInt32(d1.text)*3 + totalDamage;
                d1WasAdded = true;
            }
            else if (d2.text == d1.text & HowManyDicesKnown == 1 | d3.text == d1.text & HowManyDicesKnown == 1 | d4.text == d1.text & HowManyDicesKnown == 1)
            {
                HowManyDicesKnown++;
                Dice1.Warning("X2 dices...");
                totalDamage = System.Convert.ToInt32(d1.text)*2 + totalDamage;
                d1WasAdded = true;
            }
            else
            {
                HowManyDicesKnown++;
                totalDamage = System.Convert.ToInt32(d1.text) + totalDamage;
                d1WasAdded = true;
            }
        }
        if (Dice2.whatadice == true & d2WasAdded == false)
        {
            if (d2.text == d1.text & d3.text == d2.text & d4.text == d2.text & HowManyDicesKnown == 3)
            {
                HowManyDicesKnown++;
                Dice2.Warning("X4 DICES!!!");
                totalDamage = System.Convert.ToInt32(d2.text) * 4 + totalDamage;
                d2WasAdded = true;
            }
            else if (d2.text == d1.text & d3.text == d2.text & HowManyDicesKnown == 2 | d3.text == d2.text & d4.text == d2.text & HowManyDicesKnown == 2 | d4.text == d2.text & d2.text == d1.text & HowManyDicesKnown == 2)
            {
                HowManyDicesKnown++;
                Dice2.Warning("X3 dices!");
                totalDamage = System.Convert.ToInt32(d2.text) * 3 + totalDamage;
                d2WasAdded = true;
            }
            else if (d2.text == d1.text & HowManyDicesKnown == 1 | d2.text == d3.text & HowManyDicesKnown == 1 | d2.text == d4.text & HowManyDicesKnown == 1)
            {
                HowManyDicesKnown++;
                Dice2.Warning("X2 dices...");
                totalDamage = System.Convert.ToInt32(d2.text) * 2 + totalDamage;
                d2WasAdded = true;
            }
            else
            {
                HowManyDicesKnown++;
                totalDamage = System.Convert.ToInt32(d2.text) + totalDamage;
                d1WasAdded = true;
            }
        }
        if (Dice3.whatadice == true & d3WasAdded == false)
        {
            if (d2.text == d3.text & d3.text == d1.text & d4.text == d3.text & HowManyDicesKnown == 3)
            {
                HowManyDicesKnown++;
                Dice3.Warning("X4 DICES!!!");
                totalDamage = System.Convert.ToInt32(d3.text) * 4 + totalDamage;
                d3WasAdded = true;
            }
            else if (d2.text == d3.text & d3.text == d1.text & HowManyDicesKnown == 2 | d3.text == d1.text & d4.text == d3.text & HowManyDicesKnown == 2 | d2.text == d3.text & d4.text == d3.text & HowManyDicesKnown == 2)
            {
                HowManyDicesKnown++;
                Dice3.Warning("X3 dices!");
                totalDamage = System.Convert.ToInt32(d3.text) * 3 + totalDamage;
                d3WasAdded = true;
            }
            else if (d2.text == d3.text & HowManyDicesKnown == 1 | d3.text == d1.text & HowManyDicesKnown == 1| d4.text == d3.text & HowManyDicesKnown == 2)
            {
                HowManyDicesKnown++;
                Dice3.Warning("X2 dices...");
                totalDamage = System.Convert.ToInt32(d3.text) * 2 + totalDamage;
                d3WasAdded = true;
            }
            else
            {
                HowManyDicesKnown++;
                totalDamage = System.Convert.ToInt32(d3.text) + totalDamage;
                d1WasAdded = true;
            }
        }
        if (Dice4.whatadice == true & d4WasAdded == false)
        {
            if (d4.text == d1.text & d3.text == d4.text & d4.text == d2.text & HowManyDicesKnown == 3)
            {
                HowManyDicesKnown++;
                Dice3.Warning("X4 DICES!!!");
                totalDamage = System.Convert.ToInt32(d4.text) * 4 + totalDamage;
                d4WasAdded = true;
            }
            else if (d2.text == d4.text & d3.text == d4.text & HowManyDicesKnown == 2 | d3.text == d4.text & d4.text == d1.text & HowManyDicesKnown == 2 | d4.text == d1.text & d2.text == d4.text & HowManyDicesKnown == 2)
            {
                HowManyDicesKnown++;
                Dice3.Warning("X3 dices!");
                totalDamage = System.Convert.ToInt32(d4.text) * 3 + totalDamage;
                d4WasAdded = true;
            }
            else if (d2.text == d4.text & HowManyDicesKnown == 1 | d4.text == d1.text & HowManyDicesKnown == 1 | d4.text == d3.text & HowManyDicesKnown == 1)
            {
                HowManyDicesKnown++;
                Dice3.Warning("X2 dices...");
                totalDamage = System.Convert.ToInt32(d4.text) * 2 + totalDamage;
                d4WasAdded = true;
            }
            else
            {
                HowManyDicesKnown++;
                totalDamage = System.Convert.ToInt32(d4.text) + totalDamage;
                d1WasAdded = true;
            }
        }

    */
