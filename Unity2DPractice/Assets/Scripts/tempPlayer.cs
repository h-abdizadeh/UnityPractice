using UnityEngine;
using static UnityEngine.Input;//static

public class tempPlayer : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;

    bool goRight, goLeft, jump, climb;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        goRight = /*Input.*/GetKey(KeyCode.D);

        if (goRight)
        {
            rb2d.velocity = new Vector2(1, rb2d.velocity.y);
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
    }
}
