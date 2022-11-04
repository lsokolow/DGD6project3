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
        ChoiceLists[God.GM.PendingTurns.Count - 1].SetActive(true);
        FinishTurn = false;
       

        if (God.GM.scores.ContainsKey(God.GM.PendingTurns[0]))
        {
            FinishTurn = true;
            God.GM.SwitchTurn();
        }

        while (!FinishTurn)
        {
            yield return null;
        }

        Button.gameObject.SetActive(false);
        if (God.GM.PendingTurns[0] == Turns.Accessory)
        {
            foreach(Clothing c in God.Lib.ClothingList)
            {
                if (God.GM.scores.ContainsKey(c.Type))
                {
                    God.GM.FullScore += God.GM.scores[c.Type];
                }
            }

        }
        else
        {
            if (God.GM.scores.ContainsKey(God.GM.PendingTurns[0]))
            {
                God.GM.FullScore += God.GM.scores[God.GM.PendingTurns[0]];
            }
            
        }
        PlayerScoreText.SetText("Score:" + God.GM.FullScore);
            
        ChoiceLists[God.GM.PendingTurns.Count - 1].SetActive(false);
    }
}
