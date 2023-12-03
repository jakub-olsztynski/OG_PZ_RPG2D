using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : Collectable 
{
    public Sprite emptyChest;
    public int pesosAmount = 5;

    protected override void OnCollect() //nadpisujemy funkcjê
    {
        if(!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            Debug.Log("Grant " + pesosAmount + " pesos!");
        }
    }


}
