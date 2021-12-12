using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothing : MonoBehaviour
{
    public ClothingType Type;
    public AccessoryType AType;
    public  List <SpriteRenderer> S;

    public Library lib;


    // Start is called before the first frame update
    void Start()
    {
        
        if (GetComponent<SpriteRenderer>() != null)
        {
            S.Add(this.GetComponent<SpriteRenderer>());
        }
        if (GetComponent<SpriteRenderer>() == null)
        {
            SpriteRenderer[] srender;

            srender = GetComponentsInChildren<SpriteRenderer>();

            foreach (SpriteRenderer s in srender)
            {
                S.Add(s);
            }
        }


        
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
    Top,
    Bottom,
    Socks,
    Shoes,
    Accessory,
}

public enum AccessoryType
{
    None,
    LeftHold,
    RightHold,
    Bracelet,
    Necklace,
    Legwarmers,
    Earrings,
}
