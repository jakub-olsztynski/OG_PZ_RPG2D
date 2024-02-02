using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Damage //klasa zamieniona na struct, wywalone inheritance z MonoBehavior, rozwiazuje problem tworzenia nowych obiektow 
{
    public Vector3 origin;
    public int damageAmount;
    public float pushForce;
}
