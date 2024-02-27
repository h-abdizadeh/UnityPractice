using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class practice9_Enemy : MonoBehaviour
{
    Practice5_Move playerMove;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = FindObjectOfType<Practice5_Move>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Player --ToLower()--> player
        //Player --ToUpper()--> PLAYER
        if (collision.gameObject.tag.ToLower() is "player")
        {
            //1
            //Destroy(collision.gameObject);

            //2
            //Transform player = collision.gameObject.transform;
            //player.position = Vector3.zero;

            //3
            float enemyPosX = gameObject.transform.position.x;
            Vector3 playerPos = collision.gameObject.transform.position;
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerPos.x < enemyPosX)
            {
                playerRb.velocity = new Vector2(-5, playerRb.velocity.y);
            }
            else
            {
                playerRb.velocity = new Vector2(5, playerRb.velocity.y);
            }

            playerMove.move = false;

        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        //Player --ToLower()--> player
        //Player --ToUpper()--> PLAYER
        if (collision.gameObject.tag.ToUpper() is "PLAYER")
        {
            //0
            //playerMove.move = true;

            //1
            //StartCoroutine("Delay");
            //2
            StartCoroutine(nameof(Delay));
               
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        playerMove.move = true;
    }
}
