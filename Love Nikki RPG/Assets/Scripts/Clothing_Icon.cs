using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothing_Icon : MonoBehaviour
{
    public ClothingType Type;
    public AccessoryType AType;
    public ClothingStyle Style;

    public PageManager M;

    public List<Sprite> Clothing;
    public Clothing C;

    public Dictionary<string, float> ScoreList = new Dictionary<string, float>();

    public float MaxScore;

    [HideInInspector]
    public float CuteScore, CoolScore, SweetScore, ElegantScore;

    


    // Start is called before the first frame update
    public virtual void Start()
    {
        CalculateScores();
        ScoreList.Add("Cute", CuteScore);
        ScoreList.Add("Cool", CoolScore);
        ScoreList.Add("Sweet", SweetScore);
        ScoreList.Add("Elegant", ElegantScore);
    }

    public virtual void Update()
    {
        
    }


    public virtual void OnMouseUpAsButton()
    {
        GameManager.GM.Selected = this;
        M.AS.Play();
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

    public virtual void changeclothes()
    {
        for (int i = 0; i < Clothing.Count; i++)
        {
            C.S[i].sprite = Clothing[i];
        }

        if (Clothing.Count < C.S.Count)
        {
            C.S[C.S.Count - 1].sprite = null;
        }
    }

    public virtual void removeclothes()
    {
        for (int i = 0; i < Clothing.Count; i++)
        {
            C.S[i].sprite = null;
        }
    }

    public void CalculateScores()
    {
        switch (Style)
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

public enum ClothingStyle
{
    None,
    Cute,
    Cool,
    Sweet,
    Elegant,
}
