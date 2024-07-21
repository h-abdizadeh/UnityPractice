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
            //player.score += 1;
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
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
        }


       
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //        if(collision.gameObject.tag.ToUpper() is "PLAYER")
    //    {
    //        playerMove.move = true;
    //    }
    //}
}
