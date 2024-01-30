using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    //stats tutaj
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    //upgrade tutaj
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    //atak tutaj
    private float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start() //musi by� bo jest sprite renderer a w Collidable juz jest Start!
    {
        base.Start(); //to zostaje, box collider nadal ma by�
        spriteRenderer = GetComponent<SpriteRenderer>(); //obs�uga zmiany sprita w ramach upgradu bez generowania nowych obiektow
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space)) //sprawdza co klatke czy spacja jest wcisnieta itd
        {
            if(Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time; //reset czasu
                Swing();

            }
        }
    }
    private void Swing()
    {
        Debug.Log("AttackSetSwing");
        //Debug.Log(coll.name); //wykomentuj to, bron koliduje sie z Player
        
    }
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter") //japrdl jedyny sposob zeby samemu sobie nie walic mieczem w czo�o to otagowa� wszystko jako "Fighter"
        {
            if (coll.name == "Player") //XD zhackowane
            {
                return;
            }
            //start logiki przekazania obiektu damage
            Damage dmg = new Damage()
            {
                damageAmount = damagePoint,
                origin = transform.position, //wiadomo, ty
                pushForce = pushForce //mo�e zmie�i� nazwe tego pola tutaj albo w klasie Damage
            };
            coll.SendMessage("RecieveDamage", dmg); //obiekt dmg przekazywany metoda RecieveDamage
            //koniec logiki przekazania obiektu damage
            Debug.Log(coll.name);
        }
        
        //base.OnCollide(coll); //wywalam to, tam jest tylko debug log
    }
}
