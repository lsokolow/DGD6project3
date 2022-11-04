using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    public List<Clothing> ClothingList;

    public List<Clothing_Icon> IconList;

    public Dictionary<ClothingType, Clothing> Typedict = new Dictionary<ClothingType, Clothing>();

    //public Dictionary<Enum, PageManager> MenuDict = new Dictionary<Enum, PageManager>();

    //public Dictionary< >

    // Start is called before the first frame update
    void Awake()
    {
        God.Lib = this;
        foreach (Clothing c in ClothingList)
        {
            Typedict.Add(c.Type, c);
            Debug.Log(Typedict[c.Type]);
        }

    }

    
}
public enum ClothingType
{
    //None,
    Hair,
    Hat,
    Top,
    Bottom,
    Dress,
    Socks,
    Shoes,
    // Accessory,
    LeftHold,
    RightHold,
    Bracelet,
    Necklace,
    LegAccessory,
    Earrings,
}
public enum Turns
{
    Hair,
    Hat,
    Top,
    Bottom,
    Socks,
    Shoes,
    Accessory,
}

public enum ClothingStyle
{
    None,
    Cute,
    Cool,
    Sweet,
    Elegant,
}

public enum Sets
{
    None,
    FLowerFairyMevilla,
    RabbitSweet,
    KittenSketchbook,
    CunningImp,
}