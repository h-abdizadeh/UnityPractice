using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class tempCode : MonoBehaviour
{

    tempPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<tempPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*gameObject.*/
        transform.Rotate(0.5f * Vector3.up);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag is "Player")
        {
            player.score += 1;
            Destroy(gameObject);
        }
    }

}
