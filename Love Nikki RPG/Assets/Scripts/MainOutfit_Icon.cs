using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainOutfit_Icon : Clothing_Icon
{
    public List<ClothingType> CExtras;


    public override void Start()
    {
        base.Start();
        C = GameManager.GM.lib.Typedict[Type];
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
            if (M.ActiveOption != null && M.ActiveOption.Type == Type)
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

        foreach (ClothingType c in CExtras)
        {
            GameManager.GM.SetScores(c, 0);
        }

        GameManager.GM.SetScores(Type, ScoreList[GameManager.GM.category]);
    }
    public override void removeclothes()
    {
        base.removeclothes();

        foreach (ClothingType c in CExtras)
        {
            GameManager.GM.scores.Remove(c);
        }

        GameManager.GM.SetScores(Type, 0f);
    }
}
