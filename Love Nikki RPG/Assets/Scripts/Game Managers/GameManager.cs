﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshPro EndingText;
    public TextMeshPro TipText;
    public GameObject EndPopUp;
    public GameObject NextLvlButton;
    public GameObject ResetButton;
    public GameObject MainMenuButton;
    public GameObject PlayAgainButton;

    public TextMeshPro CategoryText;

    //Lists of all turn takers
    //Make sure to populate this in the editor
    //public List<TurnTakerController> Everyone;
    public List<Turns> PendingTurns;

    public PlayerController Player;
    public EnemyController Enemy;

    public string category;
    public Clothing_Icon Selected;

    //all of the scores combined
    public float FullScore;
    //dictionary for the type of clothing and the score each one gets

    public bool PlayerTurn;
    public Dictionary<Enum, float> scores = new Dictionary<Enum, float>();
    public Dictionary<int, string> lvlcategories = new Dictionary<int, string>();
    public int level;

    public GameObject IconPrefab;


    private void Awake()
    {
        God.GM = this;
        lvlcategories.Add(0, "Cute");
        lvlcategories.Add(1, "Sweet");
        category = lvlcategories[level];
        ExampleBuilder.Setup();

        foreach (int i in Enum.GetValues(typeof(Turns)))
        {
            PendingTurns.Add((Turns)i);
        }
        PlayerTurn = true;
        CategoryText.SetText("Category:<br>" + category);

        foreach (Example e in ExampleBuilder.Examples)
        {
            CreateIcon(IconPrefab, e);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        NextTurn();

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextTurn()
    {
        //If we've finished a full round, add everyone back to the turn order
        if (PendingTurns.Count == 0)
        {
            //yield return new WaitForSeconds(1);
            End();
        }
        if (PendingTurns.Count != 0)
        {
            //Figure out who's next, then kick off their turn
            TurnTakerController current = Player;
            if (!PlayerTurn) current = Enemy;
            StartCoroutine(RunTurn(current));
        }
        
    }

    public IEnumerator RunTurn(TurnTakerController who)
    {
        //And tell them to handle their turn
        yield return StartCoroutine(who.TakeTurn());
        //Once this is over, do the next turn
        NextTurn();
    }

    public void SetScores(Enum e, float s)
    {
        if (!scores.ContainsKey(e))
        {
            scores.Add(e, s);
        }
        if (scores.ContainsKey(e))
        {
            scores[e] = s;
        }

        foreach (KeyValuePair<Enum, float> kvp in scores)
        {
           // Debug.Log(" " + kvp.Key + " " + kvp.Value);
        }
    }

    public void SwitchTurn()
    {
        PlayerTurn = !PlayerTurn;
        if (PlayerTurn)
            PendingTurns.RemoveAt(0);
    }

    public void End()
    {
        
        if (Enemy.EnemyScore < FullScore)
        {
            if (level == 0)
            {
                NextLvlButton.SetActive(true);
            }
            if (level == 1)
            {
                PlayAgainButton.SetActive(true);
            }
            //show the win screen with the reset button and main menu button
            EndingText.SetText("You Win!"); 
        }

        if (Enemy.EnemyScore > FullScore)
        {
            //show the lose screen with the reset button and main menu button
            EndingText.SetText("You Lose.");
            TipText.SetText("Tip: Certain clothes score higher in certain categories than others.");
            ResetButton.SetActive(true);
        }
        MainMenuButton.SetActive(true);
        EndPopUp.SetActive(true);
    }

    public void Reset()
    {
        scores.Clear();
        PendingTurns.Clear();
        FullScore = 0;
        Enemy.EnemyScore = 0;

        Enemy.EnemyScoreText.SetText("Score:");
        Player.PlayerScoreText.SetText("Score:");

        category = lvlcategories[level];
        CategoryText.SetText("Category:<br>" + category);

        

        foreach (int i in Enum.GetValues(typeof(Turns)))
        {
            PendingTurns.Add((Turns)i);
        }

        foreach (Clothing c in God.Lib.ClothingList)
        {
            for (int i = 0; i < c.S.Count; i++)
            {
                c.S[i].sprite = null;
            }
        }
        Transform[] accessories = Enemy.Accessory.GetComponentsInChildren<Transform>(true);

        foreach (Transform t in accessories)
        {
            t.gameObject.SetActive(false);
        }

        foreach (GameObject g in Enemy.enemyClothes)
        {
            g.SetActive(false);
        }


        PlayerTurn = true;

        NextTurn();
    }

    public void Nextlvl()
    {
        level++;
        Reset();
    }

    public void CreateIcon(GameObject g, Example e)
    {
        Clothing_Icon c = Instantiate(g).GetComponent<Clothing_Icon>();
        c.E = e;
        c.E.C = God.Lib.Typedict[ClothingType.Hair];
        c.E.PM = God.Menus.PageDict[c.E.Type];

        c.gameObject.name = c.E.Name;
        //c.transform.parent = c.E.PM.transform;

        
    }
}