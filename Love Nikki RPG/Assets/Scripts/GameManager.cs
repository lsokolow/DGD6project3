using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

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
    public Dictionary<ClothingType, float> scores = new Dictionary<ClothingType, float>();


    private void Awake()
    {
        GM = this;
        foreach (int i in Enum.GetValues(typeof(ClothingType)))
        {
            PendingTurns.Add((ClothingType)i);
        }
        PendingTurns.Remove((ClothingType)2);
        PendingTurns.Remove((ClothingType)3);
        PlayerTurn = true;
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
            CalculateScore();
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

    public void SetScores(ClothingType t, float s)
    {
       
        if (!scores.ContainsKey(t))
        {
            scores.Add(t, s);
        }
        if (scores.ContainsKey(t))
        {
            scores[t] = s;
        }
    }

    public void SwitchTurn()
    {
        PlayerTurn = !PlayerTurn;
        if (PlayerTurn)
            PendingTurns.RemoveAt(0);
    }

    public void CalculateScore()
    {
        Debug.Log("END");
    }
}
