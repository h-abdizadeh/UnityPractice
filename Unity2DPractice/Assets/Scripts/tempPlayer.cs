using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlayer : MonoBehaviour
{
    public int score;
    public Object bullet;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            Instantiate(bullet,transform.position,transform.rotation);
            
            //FindObjectOfType<Practice9_Bullet>().fire = true;
        }
    }
}
