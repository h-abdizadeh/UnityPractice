using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniGame2_Score : MonoBehaviour
{
    public int score;
    public TMP_Text textScore;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag is "egg")
        {
            score += 1;
            textScore.text = "score : " + score;
            collision.gameObject.tag = "Untagged";
        }
    }
}
