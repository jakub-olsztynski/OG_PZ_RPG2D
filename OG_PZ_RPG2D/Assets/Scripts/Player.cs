using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
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
        //Warto zwr�ci� uwag� �e obecnie wg kodu gracz ma kolizj� z samym sob� daltego aby tego unik�� prze�aczy� trzeba opcj�: Edit>ProjectSettings>Physics2D>Queries Start in Collider

    }
}