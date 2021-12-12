using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryIcon : Clothing_Icon
{

    public List<AccessoryType> AExtras;
    

    public override void Start()
    {
        base.Start();
        C = GameManager.GM.lib.Typedict[AType];
    }

    public override void OnMouseUpAsButton()
    {
        base.OnMouseUpAsButton();
        if (M.ActiveOption == this)
        {
            removeclothes();
            M.ActiveOption = null;
        }
        else
        {
            if (M.ActiveOption != null && M.ActiveOption.AType == AType)
            {
                M.ActiveOption.removeclothes();
            }
            changeclothes();
            M.ActiveOption = this;
        }
    }

    public override void changeclothes()
    {
        base.changeclothes();

        foreach (AccessoryType a in AExtras)
        {
            GameManager.GM.SetScores(a, 0);
        }

        GameManager.GM.SetScores(AType, ScoreList[GameManager.GM.category]);
    }

    public override void removeclothes()
    {
        base.removeclothes();

        foreach (AccessoryType a in AExtras)
        {
            GameManager.GM.scores.Remove(a);
        }

        GameManager.GM.SetScores(Type, 0f);
    }
}
