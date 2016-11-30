using UnityEngine;
using System.Collections;

public class frog_MonUI : MonoBehaviour {
    public UISprite HP;
    public UISprite CD;
    public GameObject Super;
    int HPvalue;
    int fullHp;
    bool isDamaging = false;
    float x;
    float totalx = 0;
    frog_Monster Mon = null;

    // Use this for initialization
    void Start () {
        if (Mon == null)
        {
            if (frog_MonsterManager.instance.isBossComing)
                Mon = GameObject.Find("King(Clone)").GetComponent<frog_Monster>();
            else
                Mon = GameObject.Find("Mummy(Clone)").GetComponent<frog_Monster>();

            Start();
        }
        HPvalue = Mon.Hp;
        fullHp = Mon.Hp;
        CD.fillAmount = 0;
    }

    // Update is called once per frame
    void FixedUpdate () {

        if (HP.fillAmount > 0)
        {

            //Debug.Log(Mon);
            CD.fillAmount += 0.002f * Mon.CDspeed;
            Super.transform.localScale = CD.fillAmount * Vector3.one;
            if (CD.fillAmount == 1)
            {
                CD.fillAmount = 0;
                JUNK.instance.Anim();
                frog_Stagedata.instance.Hited++;
                frog_GameManager.instance.OnHited();
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
