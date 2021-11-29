using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    public List<Clothing_Icon> IconList;
    public List<Clothing> ClothingList;
    public Dictionary<ClothingType, Clothing> Typedict = new Dictionary<ClothingType, Clothing>();
    

    // Start is called before the first frame update
    void Awake()
    {
        GameManager.GM.lib = this;
        foreach (Clothing c in ClothingList)
        {
            c.lib = this;
            Typedict.Add(c.Type, c);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
//[System.Serializable]
//public class IconSelect
//{
  //  public Clothing_Icon Icon;
    //public Sprite Clothing;
//}
