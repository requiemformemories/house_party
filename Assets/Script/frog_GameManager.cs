using UnityEngine;
using System.Collections;

public class frog_GameManager : MonoBehaviour {

    public UISprite GetReady;
    public UISprite Go;

    public UISprite[] CountDown = new UISprite[3];
    public UIWidget Direct;
    public frog_ArrowCtrl A_Ctrl;

    bool isDown;
    bool isStart = false;
    float count = 4;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!isStart)
        {
            if (isDown)
            {
                count -= Time.deltaTime;
                for (int i = 0; i < 3; i++)
                {
                    CountDown[i].enabled = false;
                }
                CountDown[Mathf.FloorToInt(count)].enabled = true;
                if (count<0)
                {
                    isStart = true;
                    Direct.GetComponent<UITweener>().onFinished.Add(new EventDelegate(() => { A_Ctrl.isShootable = true; }));
                    Direct.GetComponent<UITweener>().PlayForward();
                    Go.enabled = true;
                    Go.GetComponent<UITweener>().onFinished.Add(new EventDelegate(() => { Destroy(Go.gameObject); }));
                    Go.GetComponent<UITweener>().PlayForward();
                }
            }
            if (true)
            {
                
            }
        }

    }
}
