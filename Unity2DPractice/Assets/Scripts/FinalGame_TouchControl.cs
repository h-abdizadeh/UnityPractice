using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class FinalGame_TouchControl : MonoBehaviour
{
    private FinalGame_Woodcutter _woodcutter;
    RectTransform btnRect;
    private void Start()
    {
        _woodcutter = FindObjectOfType<FinalGame_Woodcutter>();
        btnRect = GetComponent<RectTransform>();
    }
    public void GoRightPush()
    {
        _woodcutter.touchR = true;
    }
    public void GoRightPop()
    {
        _woodcutter.touchR = false;
    }
    public void GoLeftPush()
    {
        _woodcutter.touchL = true;
    }

    public void GoLeftPop()
    {
        _woodcutter.touchL = false;

    }

    public void JumpPush()
    {
        _woodcutter.touchJ = true;
        btnRect.localScale=Vector3.zero;
        StartCoroutine(nameof(Delay));

    }
    private IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(Time.deltaTime);
        _woodcutter.touchJ = false;
        //_woodcutter.touchDo = false;
        yield return new WaitForSecondsRealtime(1.5f);
        btnRect.localScale = Vector3.one;
        //JumpPop();
        //ToDoPop();
    }

    public void JumpPop()
    {
        _woodcutter.touchJ = false;      
    }
    public void ToDoPush()
    {
        _woodcutter.touchDo = true;
        //btnRect.localScale = Vector3.zero;
        //StartCoroutine(nameof(Delay));

    }
    public void ToDoPop()
    {
        _woodcutter.touchDo = false;      
    }


}
