using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothing_Icon : MonoBehaviour
{
    public ClothingType Type;
    public List<ClothingType> Extras;

    public Sprite Clothing;
    public Clothing C;
    

    public Dictionary<string, float> ScoreList = new Dictionary<string, float>();
    public float CuteScore;
    public float CoolScore;

    public PageManager M;


    // Start is called before the first frame update
    void Start()
    {
        C = GameManager.GM.lib.Typedict[Type];

        ScoreList.Add("Cute", CuteScore);
        ScoreList.Add("Cool", CoolScore);
    }

    private void OnMouseUpAsButton()
    {
        C.S.sprite = Clothing;
        GameManager.GM.Selected = this;
        M.ActiveOption = this;
    }

    public void Activate()
    {
        //Turn shiny
    }
    public void Deactivate()
    {
        //Become default color
    }

}
