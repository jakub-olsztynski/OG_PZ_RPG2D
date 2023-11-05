using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private Vector3 moveDelta;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate() //vs Update, FixedUpdate registers at fixed interval so framerate wont break phsyics
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x,y,0); //reset moveDelta for each frame

        Debug.Log(x); //comment this out in release!!!
        Debug.Log(y);

        if(moveDelta.x > 0)
        {
            transform.localScale = new Vector3(1,1,1); //flip sprite in y-axis, Vector3.one = Vector3(1,1,1)
        }
        else if(moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); //flip sprite back, (-1,0,0) makes it dissapear cause it becomes 1-dimensional
        }
        //actual movement goes here
        transform.Translate(moveDelta.normalized * Time.deltaTime); //timeDelta to normalize with framerate, .normalized to get rid of excess vertical!
    }
}
