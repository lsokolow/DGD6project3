using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    public List<Clothing> ClothingList;

    public Dictionary<Enum, Clothing> Typedict = new Dictionary<Enum, Clothing>();

    //public Dictionary< >

    // Start is called before the first frame update
    void Awake()
    {
        GameManager.GM.lib = this;
        foreach (Clothing c in ClothingList)
        {
            if (c.Type == ClothingType.Accessory)
            {
                Typedict.Add(c.AType, c);
            }
            else
            {
                Typedict.Add(c.Type, c);
            }      
        }
    }

    
}