using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothing_Icon : MonoBehaviour
{
    public ParticleSystem hearts;

    //public Sets Set;

    public SpriteRenderer SR;

    public Dictionary<string, float> ScoreList = new Dictionary<string, float>();

    public float MaxScore;

    [HideInInspector]
    public float CuteScore, CoolScore, SweetScore, ElegantScore;

    public List<ClothingType> CExtras;

    public Example E;


    // Start is called before the first frame update
    public virtual void Start()
    {
        CalculateScores();
        ScoreList.Add("Cute", CuteScore);
        ScoreList.Add("Cool", CoolScore);
        ScoreList.Add("Sweet", SweetScore);
        ScoreList.Add("Elegant", ElegantScore);

        hearts = GetComponentInChildren<ParticleSystem>();
        SR = GetComponentInChildren<SpriteRenderer>();
        SR.sprite = E.IconSprite;

        
    }

    public void Update()
    {
        
    }

    public void OnMouseUpAsButton()
    {
        God.GM.Selected = this;
        E.PM.AS.Play();
        hearts.Play();

        if (E.PM.ActiveOption == this)
        {
            removeclothes();
            E.PM.ActiveOption = null;
        }
        else
        {
            if (E.PM.ActiveOption != null && E.PM.ActiveOption.E.Type == E.Type)
            {
                E.PM.ActiveOption.removeclothes();
            }
            changeclothes();
            E.PM.ActiveOption = this;
        }
    }

    public void Activate()
    {
        //Turn shiny
        //Debug.Log(this.name + "activated");
    }
    public void Deactivate()
    {
        //Become default color
        //Debug.Log(this.name + "deactivated");
    }

    public void changeclothes()
    {
        for (int i = 0; i < E.ClothingSprites.Count; i++)
        {
            E.C.S[i].sprite = E.ClothingSprites[i];
        }

        if (E.ClothingSprites.Count < E.C.S.Count)
        {
            E.C.S[E.C.S.Count - 1].sprite = null;
        }

        foreach (ClothingType c in CExtras)
        {
            God.GM.SetScores(c, 0);
        }

        God.GM.SetScores(E.Type, ScoreList[God.GM.category]);
    }

    public void removeclothes()
    {
        for (int i = 0; i < E.ClothingSprites.Count; i++)
        {
            E.C.S[i].sprite = null;
        }

        foreach (ClothingType c in CExtras)
        {
            God.GM.scores.Remove(c);
        }

        God.GM.SetScores(E.Type, 0f);
    }

    public void CalculateScores()
    {
        switch (E.Style)
        {
            case ClothingStyle.None:
                break;

            case ClothingStyle.Cute:
                CuteScore = MaxScore;
                SweetScore = Mathf.Round(MaxScore / 2);
                CoolScore = Mathf.Round(MaxScore / 4);
                ElegantScore = Mathf.Round(MaxScore / 8);
                break;

            case ClothingStyle.Cool:
                CoolScore = MaxScore;
                CuteScore = Mathf.Round(MaxScore / 2);
                ElegantScore = Mathf.Round(MaxScore / 4);
                SweetScore  = Mathf.Round(MaxScore / 8);
                break;

            case ClothingStyle.Sweet:
                SweetScore = MaxScore;
                CuteScore = Mathf.Round(MaxScore / 2);
                ElegantScore = Mathf.Round(MaxScore / 4);
                CoolScore = Mathf.Round(MaxScore / 8);
                break;

            case ClothingStyle.Elegant:
                ElegantScore = MaxScore;
                SweetScore = Mathf.Round(MaxScore / 2);
                CuteScore = Mathf.Round(MaxScore / 4);
                CoolScore = Mathf.Round(MaxScore / 8);
                break;
        }

    }
}



