using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothing : MonoBehaviour
{
    public ClothingType Type;
    public OutfitType OType;
    public SpriteRenderer S;

    public Library lib;


    // Start is called before the first frame update
    void Start()
    {
        S = this.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}

public enum ClothingType
{
    //None,
    Hair, 
    Hat, 
    MainOutfit,
    Socks,
    Shoes,
    Bag,
}

public enum OutfitType
{
    None,
    Top,
    Bottom,
    Dress,
}
