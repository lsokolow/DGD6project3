using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public MenuPages Type;
    public List<Clothing_Icon> Options;

    public Clothing_Icon ActiveOption;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Clothing_Icon i in Options)
        {
            i.M = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (ActiveOption != null)
        {
            Clothing_Icon old = ActiveOption;

            if (ActiveOption != old)
            {
                // ActiveOption.CurrentlyActive = true;
            }
        }
    }

}

public enum MenuPages
{
    HairMenu,
    HatMenu,
    TopMenu,
    BottomMenu,
    DressMenu,
    SocksMenu,
    ShoesMenu,
    BagMenu,
}
