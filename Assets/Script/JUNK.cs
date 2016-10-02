using UnityEngine;
using System.Collections;

public class JUNK : MonoBehaviour {

    public static JUNK instance;
    public TweenRotation[] TR = new TweenRotation[3];
    public GameObject camara;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Debug.LogError("why is there two frog_MonsterManager instance?!");
            Destroy(gameObject);
        }
    }

    public void Anim()
    {
        for (int i = 0; i < 3; i++)
        {
            TR[i].onFinished.Add(new EventDelegate(() => { TR[i].enabled = false; }));
            TR[i].PlayForward();
        }
        GameObject s = (GameObject)Instantiate(Resources.Load("slash"));
        s.transform.parent = gameObject.transform;
        s.transform.localPosition = Vector3.zero;
        s.transform.localScale = Vector3.one;
        s.GetComponent<UITweener>().onFinished.Add(new EventDelegate(() => { Destroy(s); }));
        GameObject G = (GameObject)Instantiate(Resources.Load("Glass"));
        G.transform.parent = camara.gameObject.transform;
        G.transform.localPosition = Vector3.zero;
        G.transform.localScale = Vector3.one;
        G.GetComponent<UITweener>().onFinished.Add(new EventDelegate(() => { Destroy(s); }));


    }
}
