﻿using UnityEngine;
using System.Collections;

public class frog_GameManager : MonoBehaviour {

    public UISprite GetReady;
    public UISprite Go;
    public EJ_MainController Ctrl;
    public UISprite[] CountDown = new UISprite[3];
    public UIWidget Direct;
    public frog_ArrowCtrl A_Ctrl;
    int x;
    bool isDown;
    bool isStart;
    float count = 4;
    public void IsDown()
    {
        if (isDown)
        {
            isDown = false;
        }
        else
            isDown = true;
        Debug.Log(isDown);
    }
    public void IsStart()
    {
        if (isStart)
        {
            isStart = false;
        }
        else
            isStart = true;
        Debug.Log(isStart);
    }
    // Use this for initialization
    void Start ()
    {
        isStart = false;
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        isDown = Ctrl.isDown();
        //Debug.Log(Ctrl.isEnable);
        if (!isStart)
        {

            //Debug.Log(isDown);
            if (isDown)
            {
                GetReady.enabled = true;
                count -= Time.deltaTime;
                //Debug.Log(count);
                x = Mathf.FloorToInt(count);
                if (x == 3)
                {
                    CountDown[0].enabled = false;
                    CountDown[1].enabled = false;
                    CountDown[2].enabled = true;
                    Go.enabled = false;
                }
                else if (x == 2)
                {
                    CountDown[0].enabled = false;
                    CountDown[1].enabled = true;
                    CountDown[2].enabled = false;
                    Go.enabled = false;
                }
                else if (x == 1)
                {
                    CountDown[0].enabled = true;
                    CountDown[1].enabled = false;
                    CountDown[2].enabled = false;
                    Go.enabled = false;
                }
                else if (x == 0)
                {
                    CountDown[0].enabled = false;
                    CountDown[1].enabled = false;
                    CountDown[2].enabled = false;
                    GetReady.enabled = false;
                    Go.enabled = true;
                    isStart = true;
                    Direct.GetComponent<TweenAlpha>().onFinished.Add(new EventDelegate(() => { A_Ctrl.isShootable = true; Destroy(Direct.gameObject); frog_MonsterManager.instance.enabled = true; }));
                    Direct.GetComponent<TweenAlpha>().PlayForward();

                    Go.enabled = true;
                    Go.GetComponent<TweenAlpha>().onFinished.Add(new EventDelegate(() => { Destroy(Go.gameObject);Ctrl.isEnable = true; }));
                    Go.GetComponent<TweenScale>().PlayForward();
                    Go.GetComponent<TweenAlpha>().PlayForward();
                    
                }

            }
            else
            {
                count = 4;
                GetReady.enabled = false;
                Go.enabled = false;
                for (int i = 0; i < 3; i++)
                {
                    CountDown[i].enabled = false;
                }
            }
        }

    }
}
