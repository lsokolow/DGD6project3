using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : TurnTakerController
{
    public List<GameObject> enemyClothes;
    public int EnemyScore;
    public Transform Accessory;
    public TextMeshPro EnemyScoreText;

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
        Transform[] accessories = Accessory.GetComponentsInChildren<Transform>(true);

        if (GameManager.GM.PendingTurns[0] == ClothingType.Accessory)
        {
            foreach (Transform t in accessories)
            {
                t.gameObject.SetActive(true);
                EnemyScore += 10;
                yield return new WaitForSeconds(1);
            }
        }

        yield return new WaitForSeconds(1);

        enemyClothes[GameManager.GM.PendingTurns.Count - 1].SetActive(true);
        EnemyScore += 50;
        EnemyScoreText.SetText("Score:" + EnemyScore);
        GameManager.GM.SwitchTurn();
    }
}
