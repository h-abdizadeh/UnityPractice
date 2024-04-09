using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice9_Bullet : MonoBehaviour
{
    ConstantForce2D force2d;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        force2d = GetComponent<ConstantForce2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //1
        transform.Rotate(Vector3.right);

        if (rb2d.bodyType == RigidbodyType2D.Kinematic)
        {
            //jump next lines not run
            return;
        }

        //2 bullet destroy after frames
        float tmpForce = force2d.force.x;
        if (tmpForce > 0)
        {
            tmpForce -= 5 * Time.deltaTime;
            force2d.force = new Vector2(tmpForce, force2d.force.y);
        }
        else
        {
            Destroy(force2d.gameObject);
        }
    }
   
}
