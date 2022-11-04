using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataEntry
{

    //all variables on the object

    public string Name;
    public string IconArt;
    public int HP;
    public List<string> Sprites;

    //set the values
    public DataEntry(string n, string a, int i)
    {
        Name = n;
        IconArt = a;
        HP = i;

    }

    //set a specific value
    public DataEntry SetHP(int i)
    {
        HP = i;
        return this;
    }

    //add things to a list
    public DataEntry AddSprites(string s)
    {
        Sprites.Add(s);
        return this;
    }


}

//make the items
public static class DataBuilder
{
    //make a list to add things to 
    public static List<DataEntry> Examples = new List<DataEntry>();

    //run this somewhere 
    public static void Setup()
    {

        //create an item with these values assigned to the variables
        Examples.Add(new DataEntry("Name", "Sprite", 4).SetHP(3).AddSprites("Sprite1").AddSprites("Sprite2"));
    }
}