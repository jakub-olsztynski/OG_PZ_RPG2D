using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter //abstract zeby to sie nie znalaz³o na zadnym obiekcie, Mover istnieje tylko jako rozszerzaj¹ca obs³uga logiki klas dziedziczacych.
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.0f;

    protected virtual void Start() //protected zeby uniknac override gdziekolwiek
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    /*
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
    }
    */
    protected virtual void UpdateMotor(Vector3 input)
    {
        // Reset move Delta
        //moveDelta = input; //to samo co player ale nie input z klawisza a input z funkcji. Reszta funkcji bez zmian //DEPRECIJONOWANE, PATRZ ZMIANA LINIJKA PONIZEJ
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0); //nowa logika pozwalajaca przypisywac rozne x i y speed

        //Swap sprite direction
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking")); //LayerMask pozwala na blokowanie wybranych warstw w zakresie y
        if (hit.collider == null)
        {
            //Moving
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking")); //LayerMask pozwala na blokowanie wybranych warstw w zakresie x
        if (hit.collider == null)
        {
            //Moving
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
        //Warto zwróciæ uwagê ¿e obecnie wg kodu gracz ma kolizjê z samym sob¹ daltego aby tego unik¹æ prze³aczyæ trzeba opcjê: Edit>ProjectSettings>Physics2D>Queries Start in Collider
    }
}
