using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGame_platformCheck : MonoBehaviour
{
    FinalGame_Woodcutter woodcutter;
    public bool onPlatform;
    // Start is called before the first frame update
    void Start()
    {
        woodcutter=FindObjectOfType<FinalGame_Woodcutter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.ToLower() is "platform")
        {
           /// woodcutter.onPlatform = true;
           /// 
           onPlatform = true;
           transform.parent.parent=collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.ToLower() is "platform")
        {
            /// woodcutter.onPlatform = true;
            /// 
            onPlatform = false;
            transform.parent.parent = null;
        }
    }
}
