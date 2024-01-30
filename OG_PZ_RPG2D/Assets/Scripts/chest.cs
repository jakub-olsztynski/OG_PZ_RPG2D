using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : Collectable 
{
    public Sprite emptyChest;
    public int pesosAmount = 5;

    protected override void OnCollect() //nadpisujemy funkcjê dziedziczona z Cllectable ktora jest dziedziczona z Collidable
    {
        if(!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            Debug.Log("Fire ShowText instance");
            GameManager.instance.ShowText("+" + pesosAmount + " pesos!", 25, Color.yellow, transform.position, Vector3.up * 50, 3.0f);
        }
    }


}
