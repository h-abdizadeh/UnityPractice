using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice5_Move : MonoBehaviour
{
    //1
    Rigidbody2D rb2d;
    public bool goRight, goLeft, goUp, goForce;

    // Start is called before the first frame update
    void Start()
    {
        //2
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //3
        //x
        //rb2d.velocity = new Vector2(1, rb2d.velocity.y);
        //rb2d.velocity = new Vector2(5, rb2d.velocity.y);
        //rb2d.velocity = new Vector2(-1, rb2d.velocity.y);

        //y
        //rb2d.velocity = new Vector2(rb2d.velocity.x, 5);

        //x , y
        //rb2d.velocity = new Vector2(2, 3f);
        //rb2d.velocity = 
        //    new Vector2(rb2d.velocity.x + 0.01f, rb2d.velocity.y + 0.02f);


        //4
        goRight = Input.GetKey(KeyCode.D);
        goLeft = Input.GetKey(KeyCode.A);
        goForce = Input.GetKey(KeyCode.M);
        goUp = Input.GetKey(KeyCode.Space);

        if (goRight)
        {
            rb2d.velocity = new Vector2(2, rb2d.velocity.y);
        }

        if (goLeft)
        {
            rb2d.velocity = new Vector2(-2, rb2d.velocity.y);
        }

        //5
        if (goForce)
        {
            transform.Rotate(0, 0, 5);
        }


        //6
        if (goUp)
        {
            //position
            //gameObject.transform.position =
            //    new Vector3(transform.position.x,
            //                transform.position.y + 10 * Time.deltaTime,
            //                transform.position.z);

            //velocity
            rb2d.velocity = new Vector2(rb2d.velocity.x, 2);
        }


        
        //if (transform.parent!=null)
        //{
        //    var pos = transform.localPosition;
        //    var par = transform.parent;
        //    if(par.)
        //}


        //get mouse position
        //var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.localPosition = new Vector3( mousePos.x,mousePos.y,0);
    }

    
}
