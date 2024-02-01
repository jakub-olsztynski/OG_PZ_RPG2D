using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Fighter
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
       

        // Reset move Delta
        moveDelta = new Vector3(x, y, 0);

        //Swap sprite direction
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

       /* hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking")); //LayerMask pozwala na blokowanie wybranych warstw w zakresie y
        if (hit.collider == null)
        {
            //Moving
            //  transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
            newY = moveDelta.y * Time.deltaTime;
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking")); //LayerMask pozwala na blokowanie wybranych warstw w zakresie x
        if (hit.collider == null)
        {
            //Moving
            //transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
            newX = moveDelta.x * Time.deltaTime;
        }*/
        //Warto zwróciæ uwagê ¿e obecnie wg kodu gracz ma kolizjê z samym sob¹ daltego aby tego unik¹æ prze³aczyæ trzeba opcjê: Edit>ProjectSettings>Physics2D>Queries Start in Collider
        transform.Translate(GetNewPosition(moveDelta,boxCollider, Time.deltaTime));

    }
    public Vector3 GetNewPosition(Vector3 moveDelta, BoxCollider2D boxCollider, float deltaTime)
    {
       /* if (boxCollider == null) 
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }*/

        float newX = 0;
        float newY = 0;
        var x1 = transform.position;
        var x2 = boxCollider.size;
        var x3 = new Vector2(0, moveDelta.y);
        var x4 = Mathf.Abs(moveDelta.y * deltaTime);
        var x5 = LayerMask.GetMask("Actor", "Blocking");

        hit = Physics2D.BoxCast( 
            x1, 
            x2, 
            0, 
            x3, 
            x4,
            x5); //LayerMask pozwala na blokowanie wybranych warstw w zakresie y
        if (hit.collider == null)
        {
            //Moving
            //  transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
            newY = moveDelta.y * deltaTime;
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * deltaTime), LayerMask.GetMask("Actor", "Blocking")); //LayerMask pozwala na blokowanie wybranych warstw w zakresie x
        if (hit.collider == null)
        {
            //Moving
            //transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
            newX = moveDelta.x * deltaTime;
        }
        return new Vector3 (newX, newY, 0);
    }

    public Vector3 GetNewPosition2(float x, float y)
    {
     
        return new Vector3(5, 5, 0);
    }
}