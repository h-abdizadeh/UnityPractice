using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice4_RotateFan : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, -10);
    }
}
