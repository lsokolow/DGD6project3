using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTakerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual IEnumerator TakeTurn()
    {
        //Virtual function for handling a character's turn
        yield return null;
    }

    public IEnumerator ChooseClothing(ClothingType t)
    {
        yield return null;
    }
}
