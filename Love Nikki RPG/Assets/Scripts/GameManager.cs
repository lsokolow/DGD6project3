using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public TextMeshPro EndingText;
    public TextMeshPro TipText;
    public GameObject EndPopUp;

    public TextMeshPro CategoryText;

    //Lists of all turn takers
    //Make sure to populate this in the editor
    //public List<TurnTakerController> Everyone;
    public List<ClothingType> PendingTurns;

    public PlayerController Player;
    public EnemyController Enemy;

    public Library lib;

    public string category;
    public Clothing_Icon Selected;

    //all of the scores combined
    public float FullScore;
    //dictionary for the type of clothing and the score each one gets

    public bool PlayerTurn;
    public Dictionary<Enum, float> scores = new Dictionary<Enum, float>();


    private void Awake()
    {
        GM = this;
        foreach (int i in Enum.GetValues(typeof(ClothingType)))
        {
            PendingTurns.Add((ClothingType)i);
        }
        PlayerTurn = true;
        CategoryText.SetText("Category:<br>" + category);
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
            //show the win screen with the reset button and main menu button
            EndingText.SetText("You Win!");
        }

        if (Enemy.EnemyScore > FullScore)
        {
            //show the lose screen with the reset button and main menu button
            EndingText.SetText("You Lose.");
            TipText.SetText("Tip: Certain clothes score higher in certain categories than others.");
        }
        EndPopUp.SetActive(true);
    }

    public void Reset()
    {
        scores.Clear();
        FullScore = 0;
        Enemy.EnemyScore = 0;

        Enemy.EnemyScoreText.SetText("Score:");
        Player.PlayerScoreText.SetText("Score:");

        foreach (Clothing c in lib.ClothingList)
        {
            for (int i = 0; i < c.S.Count; i++)
            {
                c.S[i].sprite = null;
            }
        }
        
        foreach (GameObject g in Enemy.enemyClothes)
        {
            g.SetActive(false);
        }

        foreach (int i in Enum.GetValues(typeof(ClothingType)))
        {
            PendingTurns.Add((ClothingType)i);
        }
        PlayerTurn = true;

        NextTurn();
    }
}
