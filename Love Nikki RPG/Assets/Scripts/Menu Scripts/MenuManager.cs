using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public List<PageManager> Pages;
    public Dictionary<ClothingType, PageManager> PageDict = new Dictionary<ClothingType, PageManager>();


    // Start is called before the first frame update
    void Awake()
    {
        God.Menus = this;
        foreach (PageManager p in Pages)
        {
            PageDict.Add(p.CType, p);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public PageManager GetPage(ClothingType p)
    {
        if (PageDict.ContainsKey(p)) return PageDict[p];
        return null;
    }

}
