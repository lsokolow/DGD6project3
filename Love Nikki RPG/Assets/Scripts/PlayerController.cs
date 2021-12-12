using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : TurnTakerController
{
    //A link to the UI that lets me pick an action
    public button Button;
    public bool FinishTurn;

    public List<GameObject> ChoiceLists;

    public TextMeshPro PlayerScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override IEnumerator TakeTurn()
    {
        //At the start of my turn, turn on my action choice buttons
        Button.gameObject.SetActive(true);
        Button.R.color = Button.OriginalColor;
        ChoiceLists[GameManager.GM.PendingTurns.Count - 1].SetActive(true);
        FinishTurn = false;
       

        if (GameManager.GM.scores.ContainsKey(GameManager.GM.PendingTurns[0]))
        {
            FinishTurn = true;
            GameManager.GM.SwitchTurn();
        }

        while (!FinishTurn)
        {
            yield return null;
        }

        Button.gameObject.SetActive(false);
        if (GameManager.GM.PendingTurns[0] == ClothingType.Accessory)
        {
            foreach(Clothing c in GameManager.GM.lib.ClothingList)
            {
                if (c.Type == ClothingType.Accessory && GameManager.GM.scores.ContainsKey(c.AType))
                {
                    GameManager.GM.FullScore += GameManager.GM.scores[c.AType];
                }
            }

        }
        else
        {
            if (GameManager.GM.scores.ContainsKey(GameManager.GM.PendingTurns[0]))
            {
                GameManager.GM.FullScore += GameManager.GM.scores[GameManager.GM.PendingTurns[0]];
            }
            
        }
        PlayerScoreText.SetText("Score:" + GameManager.GM.FullScore);
            
        ChoiceLists[GameManager.GM.PendingTurns.Count - 1].SetActive(false);
    }
}
