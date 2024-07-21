using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGame_ladder : MonoBehaviour
{
    public bool broken;

    FinalGame_Woodcutter player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<FinalGame_Woodcutter>();
        broken = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.ToLower() is "player")
        {
            if (broken && player.ladderPart < 6)
            {
                //show broken ladder in player text message
                player.textMessage.text = "repair broken ladder";
            }
            else if(broken && player.ladderPart >= 6)
            {
                player.textMessage.text = 
                    "press [WORK] to fixed ladder";
                player.fixedLadder = true;

                player.ladderObject = gameObject;
                player.toDoBtn.SetActive(true);
                //this object (broken ladder)
            }
            else if (!broken)
            {
                player.textMessage.text = "";
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.ToLower() is "player")
        {
            player.textMessage.text = "";
            player.fixedLadder = false;
        }
    }
}
