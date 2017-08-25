


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public static class globals
{
    public static int knownDices = 0;
    public static int howManyDices = 4;
}

public class WhatADice : MonoBehaviour
{
    System.Random rnd = new System.Random();
    public char TypeOfDice = 'a';
    public bool trueDice = true;
    public bool whatadice = false;
    public Text WarningText;
    public Text Number;
    public Button btn;
    public Sprite Dice11;
    public Sprite Dice12;
    public Sprite Dice13;
    public Sprite Dice14;
    public Sprite Dice21;
    public Sprite Dice22;
    public Sprite Dice23;
    public Sprite Dice24;
    public Sprite Dice31;
    public Sprite Dice32;
    public Sprite Dice33;
    public Sprite Dice34;
    public Sprite Dice41;
    public Sprite Dice42;
    public Sprite Dice43;
    public Sprite Dice44;
    public Sprite Dice51;
    public Sprite Dice52;
    public Sprite Dice53;
    public Sprite Dice54;
    public Sprite Dice61;
    public Sprite Dice62;
    public Sprite Dice63;
    public Sprite Dice64;
    public Image question;

    public SpriteRenderer Render;
    public Sprite[] diceSprites;

    private int number = 0;

    private AttackScript attack;

    void Awake()
    {
        //diceSprites = Resources.LoadAll<Sprite>("Dice Simple");
    }

    // Use this for initialization
    void Start()
    {
        Render = GetComponent<SpriteRenderer>();

        attack = GameObject.Find("AttackBtn").GetComponent<AttackScript>();

        InvokeRepeating("diceQue", 1.0f, 0.3f);
        btn.onClick.AddListener(Click);
        if (trueDice == false)
        {
            btn.enabled = false;
        }

        diceSprites[0] = Dice11;
        diceSprites[1] = Dice21;
        diceSprites[2] = Dice31;
        diceSprites[3] = Dice41;
        diceSprites[4] = Dice51;
        diceSprites[5] = Dice61;
        diceSprites[6] = Dice12;
        diceSprites[7] = Dice22;
        diceSprites[8] = Dice32;
        diceSprites[9] = Dice42;
        diceSprites[10] = Dice52;
        diceSprites[11] = Dice62;
        diceSprites[12] = Dice13;
        diceSprites[13] = Dice23;
        diceSprites[14] = Dice33;
        diceSprites[15] = Dice43;
        diceSprites[16] = Dice53;
        diceSprites[17] = Dice63;
        diceSprites[18] = Dice14;
        diceSprites[19] = Dice24;
        diceSprites[20] = Dice34;
        diceSprites[21] = Dice44;
        diceSprites[22] = Dice54;
        diceSprites[23] = Dice64;
    }

    void Click()
    {
        if (whatadice == false)
        {
            number = rnd.Next(1, 6);
            switch (number)
            {
                case 1:
                    switch (rnd.Next(1, 4))
                    {
                        case 1:
                            Render.sprite = diceSprites[0];
                            break;
                        case 2:
                            Render.sprite = diceSprites[6];
                            break;
                        case 3:
                            Render.sprite = diceSprites[12];
                            break;
                        case 4:
                            Render.sprite = diceSprites[18];
                            break;
                    }
                    break;
                case 2:
                    switch (rnd.Next(1, 4))
                    {
                        case 1:
                            Render.sprite = diceSprites[1];
                            break;
                        case 2:
                            Render.sprite = diceSprites[7];
                            break;
                        case 3:
                            Render.sprite = diceSprites[13];
                            break;
                        case 4:
                            Render.sprite = diceSprites[19];
                            break;
                    }
                    break;
                case 3:
                    switch (rnd.Next(1, 4))
                    {
                        case 1:
                            Render.sprite = diceSprites[2];
                            break;
                        case 2:
                            Render.sprite = diceSprites[8];
                            break;
                        case 3:
                            Render.sprite = diceSprites[14];
                            break;
                        case 4:
                            Render.sprite = diceSprites[20];
                            break;
                    }
                    break;
                case 4:
                    switch (rnd.Next(1, 4))
                    {
                        case 1:
                            Render.sprite = diceSprites[3];
                            break;
                        case 2:
                            Render.sprite = diceSprites[9];
                            break;
                        case 3:
                            Render.sprite = diceSprites[15];
                            break;
                        case 4:
                            Render.sprite = diceSprites[21];
                            break;
                    }
                    break;
                case 5:
                    switch (rnd.Next(1, 4))
                    {
                        case 1:
                            Render.sprite = diceSprites[4];
                            break;
                        case 2:
                            Render.sprite = diceSprites[10];
                            break;
                        case 3:
                            Render.sprite = diceSprites[16];
                            break;
                        case 4:
                            Render.sprite = diceSprites[22];
                            break;
                    }
                    break;
                case 6:
                    switch (rnd.Next(1, 4))
                    {
                        case 1:
                            Render.sprite = diceSprites[5];
                            break;
                        case 2:
                            Render.sprite = diceSprites[11];
                            break;
                        case 3:
                            Render.sprite = diceSprites[17];
                            break;
                        case 4:
                            Render.sprite = diceSprites[23];
                            break;
                    }
                    break;
            }

            whatadice = true;
            question.enabled = false;
            Number.text = System.Convert.ToString(number);
            if (number != 1)
            {
                Number.text = System.Convert.ToString(number);
            }
            else
            {
                Warning("Rolled 1 - miss...");

                EndPhase();
                EndTurn();
            }
        }
    }

    void Update()
    {

    }

    public void Warning(string str)
    {
        GameObject.Find("WarningText").GetComponent<WarningTextScript>().NewMessage(str);
    }

    void EndTurn()
    {
        attack.ChangeTotalAttack(0);
        attack.EndTurn();
    }

    public void ChangeAttack(int newAttack)
    {
        Number.text = System.Convert.ToString(newAttack);
    }

    public void EndPhase()
    {
        whatadice = false;
        Number.text = "0";
    }

    void diceQue()
    {
        if (whatadice == false)
        {
            Render.sprite = diceSprites[rnd.Next(0, 24)];

            question.enabled = true;
            question.color = Random.ColorHSV(0, 1, 0, 1, 0, 1, 1, 1);
        }
    }
}
