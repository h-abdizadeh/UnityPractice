using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class tempCode : MonoBehaviour
{
    float start, end;
    bool right;
    // Start is called before the first frame update
    void Start()
    {
        start = gameObject.transform.position.x;
        end = start + 10;
        right = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 platformPos = gameObject.transform.position;

        if (platformPos.x < end && right)
        {
            gameObject.transform.position =
                new Vector3(platformPos.x + 2 * Time.deltaTime,
                            platformPos.y,
                            platformPos.z);
        }
        else if (platformPos.x >= end && right)
        {
            right = false;
        }
        else if (platformPos.x > start && !right)
        {
            gameObject.transform.position =
                new Vector3(platformPos.x - 2 * Time.deltaTime,
                            platformPos.y,
                            platformPos.z);
        }
        else if(platformPos.x <= start && !right)
        {
            right = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.transform.parent=
                gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
