using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class MiniGame2_Player : MonoBehaviour
{
    Rigidbody2D rb2d;
    bool goLeft, goRight,pressE,click;
    public GameObject egg;
    public TMP_Text tryText;
    public int dropEggTry;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        goLeft=Input.GetKey(KeyCode.A);
        goRight=Input.GetKey(KeyCode.D);

        if (goLeft)
        {
            rb2d.velocity =4* Vector2.left;
        }
        if (goRight)
        {
            rb2d.velocity =4* Vector2.right;
        }

        pressE = Input.GetKeyDown(KeyCode.E);
        click = Input.GetKeyDown(KeyCode.Mouse0);

        //if (Input.GetKey(KeyCode.Mouse0))
        //if (Input.GetKeyUp(KeyCode.Mouse0))
        if (pressE || click)
        {
            //var tmpEgg =
                Instantiate(egg, transform.position, transform.rotation);

            dropEggTry += 1;
            tryText.text = "try : " + dropEggTry;
            //tmpEgg.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
