using UnityEngine;
using System.Collections;

public class frog_MonsterManager : MonoBehaviour {
    public static frog_MonsterManager instance;
    string M_name;
    public bool isNomonster;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Debug.LogError("why is there two frog_MonsterManager instance?!");
            Destroy(gameObject);
        }
        isNomonster = true;
    }

    // Use this for initialization
	
	// Update is called once per frame
	void Update ()
    {
        if (isNomonster)
        {

            if (frog_Stagedata.instance.monster > 2)
                M_name = "King";
            else
                M_name = "Mummy";

            Debug.Log("怪物"+frog_Stagedata.instance.monster);
            GameObject monster = (GameObject)Instantiate(Resources.Load(M_name));
            monster.transform.parent = gameObject.transform;
            monster.transform.localPosition = Vector3.zero;
            monster.transform.localScale = Vector3.one;
            gameObject.GetComponent<UITweener>().PlayForward();
            frog_Monster data = monster.GetComponent<frog_Monster>();
            data.Hp = 5000; // * frog_Stagedata.instance.level;
            data.CDspeed = Random.Range(1f, 6f);
            data.atk = Mathf.FloorToInt(100 / data.CDspeed);
            isNomonster = false;
        }
	}
}
