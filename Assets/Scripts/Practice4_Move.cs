using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice4_Move : MonoBehaviour
{
    Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        //1
        //gameObject.transform.position =
        //    new Vector3(0, 0, 0);

        //2
        //playerPos = gameObject.transform.position;

        //gameObject.transform.position =
        //    new Vector3(playerPos.x, playerPos.y + 5, playerPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        //1
        //gameObject.transform.position =
        //    new Vector3(0, 0, 0);

        //3
        playerPos = transform.position;
        transform.position =
            new Vector3(playerPos.x + 0.01f, playerPos.y, playerPos.z);
    }
}
