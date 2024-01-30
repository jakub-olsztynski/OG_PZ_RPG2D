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

    protected override void Start() //musi byæ bo jest sprite renderer a w Collidable juz jest Start!
    {
        base.Start(); //to zostaje, box collider nadal ma byæ
        spriteRenderer = GetComponent<SpriteRenderer>(); //obs³uga zmiany sprita w ramach upgradu bez generowania nowych obiektow
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
        if (coll.tag == "Fighter") //japrdl jedyny sposob zeby samemu sobie nie walic mieczem w czo³o to otagowaæ wszystko jako "Fighter"
        {
            if (coll.name == "Player") //XD zhackowane
            {
                return;
            }
            Debug.Log(coll.name);
        }
        
        //base.OnCollide(coll); //wywalam to, tam jest tylko debug log
    }
}
