using UnityEngine;
using System.Collections;

public class frog_MonUI : MonoBehaviour {
    public UISprite HP;
    public UISprite CD;
    public GameObject Super;
    public TweenAlpha Blood;
    float CDvalue;
    int HPvalue;
    int fullHp;
    bool isDamaging = false;
    float x;
    float totalx = 0;
    frog_Monster Mon;

    // Use this for initialization
    void Start () {
        if (Mon!=null)
        {
            HPvalue = Mon.Hp;
            fullHp = Mon.Hp;
            CDvalue = Mon.CDspeed;

        }
        CD.fillAmount = 0;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (Mon == null)
        {
            Mon = GameObject.Find("Mummy(Clone)").GetComponent<frog_Monster>();

            Start();
        }
        else
        {

            //Debug.Log(Mon);
            CD.fillAmount += 0.002f * Mon.CDspeed;
            Super.transform.localScale = CD.fillAmount * Vector3.one;
            if (CD.fillAmount == 1)
            {
                CD.fillAmount = 0;
                frog_Stagedata.instance.playerHp -= 10*Mon.atk;
                JUNK.instance.Anim();
                
                Debug.Log(frog_Stagedata.instance.playerHp);
            }
            if ((frog_Stagedata.instance.playerHp / 1000) < 0.5)
            {
                Blood.to = 1 - (frog_Stagedata.instance.playerHp / 1000);
            }
            if (HPvalue > Mon.Hp)
            {
                isDamaging = true;
                int delta = HPvalue - Mon.Hp;
                x = (float)delta / (float)fullHp;
                if (totalx == 0)
                {
                    totalx = x;
                }
                HP.fillAmount -= 0.02f;
                if (HP.fillAmount < 1 - totalx)
                {
                    isDamaging = false;
                    totalx += x;
                }

            }
            if (!isDamaging)
                HPvalue = Mon.Hp;
        }

    }
    //void Anim()
    //{
    //    for (int i = 0; i < 3; i++)
    //    {
    //        TR[i].onFinished.Add(new EventDelegate(() => { TR[i].enabled = false; }));
    //        TR[i].PlayForward();
    //    }
    //    Slash.PlayForward();
    //}
}
