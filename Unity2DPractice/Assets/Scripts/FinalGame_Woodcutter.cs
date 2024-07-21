using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Input;//static
using TMPro;
using UnityEngine.VFX;
using System.Xml.Schema;
using System.Security.Cryptography;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor;
using System.Linq;

public class FinalGame_Woodcutter : MonoBehaviour
{
    public List<GameObject> boxes = new List<GameObject>();
    Rigidbody2D rb2d;
    bool goRight, goLeft, jump, climb, toDo, inTrigger;
    public bool touchR, touchL, touchJ, touchDo;
    public bool fixedLadder,onPlatform;
    Animator animator;
    GameObject tmpLadder;

    public TMP_Text textMessage, textLadderCounter;
    public int ladderPart;//6 part to repair broken ladder

    //fixed ladder
    //1
    public Sprite ladder;
    public GameObject ladderObject;

    //2 after fixed ladder
    FinalGame_ladder ladderCode;

    //touch controller
    FinalGame_TouchControl touchControl;


    //FinalGame_ladderItem ladderItem;
    public List<int> indexList = new List<int>();


    //dynamic background
    public Transform bg;

    public GameObject toDoBtn;
    // Start is called before the first frame update
    void Start()
    {
        ladderCode = FindObjectOfType<FinalGame_ladder>();
        //ladderItem = FindObjectOfType<FinalGame_ladderItem>();
        touchControl = FindObjectOfType<FinalGame_TouchControl>();

        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        boxes = GameObject.FindGameObjectsWithTag("ladderItem").ToList();

        int indexCounter = 0;
        indexList.Add( Random.Range(0, boxes.Count));
        indexCounter++;
        while (indexCounter < 6)
        {
            int i = Random.Range(0, boxes.Count);
            if (!indexList.Contains(i))
            {
                indexList.Add(i);
                indexCounter++;

            }
        }
        foreach (var index in indexList)
        {
            boxes[index].GetComponent<FinalGame_ladderItem>().ladder = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        goRight = /*Input.*/GetKey(KeyCode.D) || touchR;
        goLeft = GetKey(KeyCode.A) || touchL;
        jump = GetKeyDown(KeyCode.Space) || touchJ;

        var playerPos=transform.position;

        if (goRight)
        {
            GetComponent<SpriteRenderer>().flipX = false;

            //transform.position = new Vector3(playerPos.x+Time.deltaTime, playerPos.y, playerPos.z);
            rb2d.velocity = new Vector2(2f, rb2d.velocity.y);
            animator.SetBool("jump", false);
            animator.SetBool("walk", true);
            bg.localPosition = new Vector3(bg.transform.localPosition.x - Time.deltaTime / 2,
                bg.transform.localPosition.y,
                 bg.transform.localPosition.z);
        }

        if (goLeft)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            //transform.position = new Vector3(playerPos.x - Time.deltaTime, playerPos.y, playerPos.z);

            rb2d.velocity = new Vector2(-2f, rb2d.velocity.y);
            animator.SetBool("jump", false);
            animator.SetBool("walk", true);

            bg.localPosition = new Vector3(bg.transform.localPosition.x + Time.deltaTime / 2,
               bg.transform.localPosition.y,
                bg.transform.localPosition.z);
        }

        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 5.5f);
            animator.SetBool("jump", true);

        }





        if (!goRight && !goLeft && !jump)
        {
            animator.SetBool("walk", false);
            animator.SetBool("jump", false);
            //animator.SetBool("attack", false);
        }


        //fixed ladder
        var pressE = GetKey(KeyCode.E ) || touchDo;
        if (fixedLadder && ladderCode.broken && pressE)
        {
            ladderObject.GetComponent<SpriteRenderer>().sprite = ladder;
            ladderCode.broken = false;
            ladderPart -= 6;
            textLadderCounter.text = ladderPart + "/6";
            animator.SetBool("attack", true);
            toDoBtn.SetActive(false);
        }
    }



    private IEnumerator GetLadder()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        Destroy(tmpLadder);

    }
    //private IEnumerator GetLadder()
    private IEnumerator OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.ToLower() is "ladderitem")
        {
            if (GetKey(KeyCode.LeftShift) || touchDo)
            {
                //collision.transform.tag = "Untagged";
                touchDo = false;
                //animator.SetBool("attack", true);
                //StartCoroutine(nameof(GetLadder));
                //toDoBtn.SetActive(false);
                animator.SetBool("attack", true);
                yield return new WaitForSecondsRealtime(0.25f);
                collision.GetComponent<ParticleSystem>().Play();
                //ladderItem.broken = true;


                //yield return new WaitForSecondsRealtime(0.4f);
                collision.GetComponent<SpriteRenderer>().enabled = false;
                //yield return new WaitForSecondsRealtime(0.25f);
                //yield return new WaitForSeconds(1);
                animator.SetBool("attack", false);
                //inTrigger = false;

                if (collision.GetComponent<FinalGame_ladderItem>().ladder)
                {
                    ladderPart++;
                    textLadderCounter.text = $"{ladderPart}/6";
                }
                

                //StartCoroutine(nameof(GetLadder));
                yield return new WaitForSecondsRealtime(1.0f);
                Destroy(collision.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.tag.ToLower() is "ladderitem")
            {

                toDoBtn.SetActive(true);

        //        //if (tmpLadder is null)
        //        //    tmpLadder = collision.gameObject;
        //        //if (inTrigger )
        //        //{

        //        //    animator.SetBool("attack", true);
        //        //    //yield return new WaitForSecondsRealtime(0.5f);
        //        //    collision.gameObject.GetComponent<ParticleSystem>().Play();
        //        //    collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //        //    yield return new WaitForSeconds(1);
        //        //    inTrigger = false;
        //        //    Destroy(collision.gameObject);
        //        //    animator.SetBool("attack", false);
        //        //    toDoBtn.SetActive(false);

        //        //    ladderPart++;
        //        //    textLadderCounter.text = $"{ladderPart}/6";
        //        //}

            }
        }

        private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.ToLower() is "ladderitem")
        {
            toDoBtn.SetActive(false);

            inTrigger = false;
        }
    }
}
