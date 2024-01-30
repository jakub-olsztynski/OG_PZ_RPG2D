using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    protected bool collected; //protected zeby obiekty klas dziedziczacych nadal mialy dostep

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            OnCollect();
        }
    }

    protected virtual void OnCollect()
    {
        collected = true;
    }
}
