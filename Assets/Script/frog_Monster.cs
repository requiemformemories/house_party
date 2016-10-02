using UnityEngine;
using System.Collections;

public class frog_Monster : MonoBehaviour {
    bool isDead = false;
    public TweenAlpha TA;
    public int Hp;
    public float CDspeed;
    public int atk;
    public void DestoryThis()
    {
        Destroy(gameObject);
    }
    

    void Update()
    {
        Debug.Log(Hp);
        if (Hp<=0)
        {
            TA.onFinished.Add(new EventDelegate(() =>
            {
                Destroy(gameObject);
                frog_MonsterManager.instance.isNomonster = true;
            }));
            TA.PlayForward();
        }
    }
}
