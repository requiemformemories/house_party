using UnityEngine;
using System.Collections;

public class frog_Monster : MonoBehaviour {
    public bool isDead = false;
    public bool isBoos;
    string MonsterName;
    public UILabel UIMonsterName;

    public TweenAlpha TA;
    public int Hp;
    public float CDspeed;
    public int atk;

    public void DestoryThis()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        if (isBoos)
            MonsterName = "King";
        else
            MonsterName = "Mummy";
        UIMonsterName.text = MonsterName;

    }

    void Update()
    {
        //Debug.Log(Hp);
        if (!isDead )
        {
            if (Hp <= 1)
            {
                frog_Stagedata.instance.monster++;

                frog_Stagedata.instance.level++;
                TA.onFinished.Add(new EventDelegate(() =>
                {
                    Destroy(gameObject);
                    frog_MonsterManager.instance.isNomonster = true;
                }));
                TA.PlayForward();
                isDead = true;
            }
            if (frog_Stagedata.instance.monster == 6)
            {
                frog_GameManager.instance.Win();
            }
        }
    }
}
