using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame1 : MonoBehaviour
{
    //code on door in scene

    int count;
    practice8_Player player;

    public GameObject lastCoin;

    // Start is called before the first frame update
    void Start()
    {
        count = 6;
        player = FindObjectOfType<practice8_Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.score==count/*6*/)
        {
            //door
            transform.GetComponent<BoxCollider2D>().enabled = false;
            transform.GetComponent<Rigidbody2D>().freezeRotation = false;

            //lastCoin
            lastCoin.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
