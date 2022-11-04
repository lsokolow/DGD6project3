using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public ClothingType CType;

    public Clothing_Icon ActiveOption;

    public AudioSource AS;


    // Start is called before the first frame update
    void Start()
    {
        if(!God.Menus.Pages.Contains(this))
            God.Menus.Pages.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (ActiveOption != null)
        {
            Clothing_Icon old = ActiveOption;

            if (ActiveOption != old)
            {
                 //ActiveOption.CurrentlyActive = true;
            }
        }
    }

}
