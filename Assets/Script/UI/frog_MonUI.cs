using UnityEngine;
using System.Collections;

public class frog_MonUI : MonoBehaviour {
    public UISprite HP;
    public UISprite CD;
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

            Debug.Log(Mon);
            CD.fillAmount += 0.002f * Mon.CDspeed;
            if (CD.fillAmount == 1)
            {
                CD.fillAmount = 0;
                frog_Stagedata.instance.playerHp -= Mon.atk;
                //Debug.Log(frog_Stagedata.instance.playerHp);
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

}
