using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;
    //niesmiertelnosc latency
    public float immuneTime = 1.0f;
    public float lastImmune;
    //push
    protected Vector3 pushDirection;
    //implementacja recieveDamage
    protected virtual void RecieveDamage(Damage dmg)
    {
        if(Time.time - lastImmune > immuneTime)  //prostsze niz wyglada, sprawdza czy jest immune
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce; //mozliwe ze normalizacja po calosci, ale wydaje sie ok

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), transform.position, Vector3.zero, 0.5f);

            if(hitpoint <= 0)
            {
                hitpoint = 0; //jak hitpointy spadaly do negatywu to by³y babole póŸniej
                Die();
            }
        }
    }
    protected virtual void Die()
    {

    }
}
