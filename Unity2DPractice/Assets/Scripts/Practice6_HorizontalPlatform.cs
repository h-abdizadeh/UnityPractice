using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice6_HorizontalPlatform : MonoBehaviour
{
    Rigidbody2D platformRb2d;
    //on X Axis
    public float startPos, endPos;
    public bool right;
    // Start is called before the first frame update
    void Start()
    {
        platformRb2d = GetComponent<Rigidbody2D>();

        startPos = gameObject.transform.position.x;
        //endPos = startPos + 10;
        right = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 platformPos = gameObject.transform.position;

        if (platformPos.x < endPos && right)
        {
            transform.position =
               new Vector3(platformPos.x + 2 * Time.deltaTime,
                           platformPos.y,
                           platformPos.z);
        }
        else if (platformPos.x >= endPos && right)
        {
            right = false;
        }
        else if (platformPos.x > startPos && !right)
        {
            transform.position =
               new Vector3(platformPos.x - 2 * Time.deltaTime,
                           platformPos.y,
                           platformPos.z);
        }
        else if (platformPos.x <= startPos && !right)
        {
            right = true;
        }
    }

    //practice 7
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.transform.parent =
                                        gameObject.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
