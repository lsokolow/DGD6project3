using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : TurnTakerController
{
    public List<GameObject> enemyClothes;

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

        //while (!GameManager.GM.PlayerTurn)
        //{
            yield return new WaitForSeconds(1);
        //  }
        enemyClothes[GameManager.GM.PendingTurns.Count - 1].SetActive(true);
        GameManager.GM.SwitchTurn();
    }
}
