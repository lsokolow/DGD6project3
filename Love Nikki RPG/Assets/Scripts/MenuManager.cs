using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public List<PageManager> Pages;
    public Dictionary<MenuPages, PageManager> PageDict = new Dictionary<MenuPages, PageManager>();


    // Start is called before the first frame update
    void Start()
    {
        foreach (PageManager p in Pages)
        {
            PageDict.Add(p.Type, p);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public PageManager GetPage(MenuPages p)
    {
        if (PageDict.ContainsKey(p)) return PageDict[p];
        return null;
    }

}
