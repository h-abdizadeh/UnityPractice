using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempBullet : MonoBehaviour
{
    ConstantForce2D force2D;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        force2D = GetComponent<ConstantForce2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb2d.bodyType==RigidbodyType2D.Kinematic)
        {
            return;
        }

        //1
        transform.Rotate(Vector3.right);//(1, 0, 0)


        //2
        float tmpForce = force2D.force.x;

        if (tmpForce > 0)
        {
            tmpForce -= 5 * Time.deltaTime;
            force2D.force = new Vector2(tmpForce, force2D.force.y);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
