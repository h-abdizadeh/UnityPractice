using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice6_VerticalPlatform : MonoBehaviour
{
    Rigidbody2D platformRb2d;
    //on Y Axis
    float startPos, endPos;
    public bool up;

    // Start is called before the first frame update
    void Start()
    {
        platformRb2d = GetComponent<Rigidbody2D>();

        startPos = gameObject.transform.position.y;
        endPos = startPos + 8;
        up = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 platformPos = gameObject.transform.position;

        if (platformPos.y < endPos && up)
        {
            transform.position =
               new Vector3(platformPos.x,
                           platformPos.y + 2 * Time.deltaTime,
                           platformPos.z);
        }
        else if (platformPos.y >= endPos && up)
        {
            up = false;
        }
        else if (platformPos.y > startPos && !up)
        {
            transform.position =
               new Vector3(platformPos.x,
                           platformPos.y - 2 * Time.deltaTime,
                           platformPos.z);
        }
        else if (platformPos.y <= startPos && !up)
        {
            up = true;
        }
    }
}
