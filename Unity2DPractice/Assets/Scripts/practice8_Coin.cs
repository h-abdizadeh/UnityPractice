using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class practice8_Coin : MonoBehaviour
{
    practice8_Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<practice8_Player>();
    }

    // Update is called once per frame
    void Update()
    {
        /*gameObject.*/
        transform.Rotate(0.5f * Vector3.up);//left,right,down
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag is "Player")
        {
            player.score += 1;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(transform.tag is "LastCoin" && 
            collision.transform.tag is "Player")
        {
            player.score += 1;
            Destroy(gameObject);
        }
    }
}
