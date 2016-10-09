using UnityEngine;
using System.Collections;

public class JUNK : MonoBehaviour {

    public static JUNK instance;
    public GameObject camara;


    void Awake()
    {
        camara = GameObject.Find("Camera");
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
