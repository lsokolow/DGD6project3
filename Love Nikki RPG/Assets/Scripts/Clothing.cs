using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothing : MonoBehaviour
{
    //this class is for things pertaining to the actual game objects that all the clothing sprites are applied to in game
    //for things relating to the actual different clothing items in game, see clothing_icon

    public ClothingType Type;
    public  List <SpriteRenderer> S;

    public Library lib;

    void Start()
    {
        //if the sprite renderer for this object exists, add it to the list of sprite renderers
        //for the items of clothing that only have one part 
        if (GetComponent<SpriteRenderer>() != null)
        {
            S.Add(this.GetComponent<SpriteRenderer>());
        }

        //if the sprite renderer for this object doesnt exist
        //for items of clothing with multiple parts
        if (GetComponent<SpriteRenderer>() == null)
        {
            //create a list of sprite renderers call sreneder
            SpriteRenderer[] srender;

            //get the sprite renderers in the children of the object and add it to srender,
            srender = GetComponentsInChildren<SpriteRenderer>();

            //add each item in srender to the main list 
            foreach (SpriteRenderer s in srender)
            {
                S.Add(s);
            }
        }


        
    }
}

