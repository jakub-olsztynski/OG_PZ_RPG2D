using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))] //nie wstawiaj tego redznie
public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
        //tu sie dzieje magia kolizji
    {
        boxCollider.OverlapCollider(filter,hits);
        for(int i =0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }
            OnCollide(hits[i]);

            hits[i] = null; //czyszczenie arraya kolizji
        }
    }

    protected virtual void OnCollide(Collider2D coll)
    {
        Debug.Log("OnCollide TODO (brak implementacji) " + this.name); //dziedziczenie z OnCollide, przekazanie nazwy(typu)obiektu
    }

}
