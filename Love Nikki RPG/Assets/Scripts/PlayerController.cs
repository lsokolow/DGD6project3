using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : TurnTakerController
{
    //A link to the UI that lets me pick an action
    public GameObject Button;
    public bool FinishTurn;

    public List<GameObject> ChoiceLists;

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
        Button.SetActive(true);
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

        if (GameManager.GM.Selected != null)
        {
            GameManager.GM.SetScores(GameManager.GM.Selected.Type, GameManager.GM.Selected.ScoreList[GameManager.GM.category]);
            foreach (ClothingType t in GameManager.GM.Selected.Extras)
            {
                GameManager.GM.SetScores(t, 0);
            }
        }

        Button.SetActive(false);
        ChoiceLists[GameManager.GM.PendingTurns.Count - 1].SetActive(false);
    }
}
