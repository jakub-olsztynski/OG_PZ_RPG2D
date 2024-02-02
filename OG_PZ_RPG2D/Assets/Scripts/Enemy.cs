using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    public int xpValue = 1;

    public float triggerLength = 1.0f;
    public float chaseLength = 5.0f;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    //hitbox bo weapon jest "wirtualny"
    private BoxCollider2D hitbox;
    public ContactFilter2D filter; //zapomnia³em ¿e tego nie dziedzicze, teraz dzia³a
    //nie wiem jak zrobic inheritance z Collidable i Mover jednoczesnie, moze wywalic wirtualne bronie do nowej klasy? na razie logika tutaj
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>(); //.GetChild(index) chwyta <index> w kolejnosci element w drzewku, wirtualny hitbox zawsze musi byc pierwszy pod <Enemy>
    }
    private void FixedUpdate()
    {
        if(Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
            {
                chasing = true;
            }
            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized); //tutaj magia gonienia, sprawdz operacje matematyczne na wektorach
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position); //powrot do spawna
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position); //powrot do spawna
            chasing = false;
        }
        //UpdateMotor(Vector3.zero); //Vector3.zero = 0,0,0

        //overlap?
        collidingWithPlayer=false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }
            if(hits[i].tag=="Fighter" && hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }

            hits[i] = null; //czyszczenie arraya kolizji
        }
        
    }
}
