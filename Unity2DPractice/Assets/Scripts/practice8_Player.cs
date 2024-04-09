using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class practice8_Player : MonoBehaviour
{
    public int score;

    public GameObject scoreText;

    //practice9_bullet
    //prefab
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //practice9_bullet
        var fireKey = Input.GetKeyUp(KeyCode.E);
        if (fireKey)
        {

            var tmpBullet = 
                Instantiate(bullet, transform.position, transform.rotation);

            tmpBullet.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        }
    }
}
