using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public PlayerController Player;

    private void OnMouseDown()
    {
        //If I click the button, set the chosen action
        Player.FinishTurn = true;
        GameManager.GM.SwitchTurn();
    }

}
