using UnityEngine;
using System.Collections;

public class frog_MonsterManager : MonoBehaviour {
    public static frog_MonsterManager instance;
    string M_name;
    public bool isNomonster;
    public bool isBossComing = false;
    public int BossStage;
    bool isArcadeMode;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Debug.LogError("why is there two frog_MonsterManager instance?!");
            Destroy(gameObject);
        }

        SetStageMode(Parameter.Mode);
        isNomonster = true;
    }

    // Use this for initialization
	
	// Update is called once per frame
	void Update ()
    {
        if (isNomonster)
        {

            if (frog_Stagedata.instance.monster == BossStage && isArcadeMode)
            {
                isBossComing = true;
                M_name = "King";
            }
            else if (frog_Stagedata.instance.monster < BossStage || !isArcadeMode)
                M_name = "Mummy";
            else
                return;

            GameObject monster = (GameObject)Instantiate(Resources.Load(M_name));
            monster.transform.parent = gameObject.transform;
            monster.transform.localPosition = Vector3.zero;
            monster.transform.localScale = Vector3.one;
            gameObject.GetComponent<UITweener>().PlayForward();
            frog_Monster data = monster.GetComponent<frog_Monster>();
            data.Hp = 5000; // * frog_Stagedata.instance.level;
            data.CDspeed = Random.Range(4f, 6f);
            data.atk = Mathf.FloorToInt(100 / data.CDspeed);
            isNomonster = false;
        }
	}

    void SetStageMode(int Mode)
    {
        switch (Mode)
        {
            case 0:
                {
                    BossStage = 5;
                    isArcadeMode = true;
                    break;
                }
            case 1:
                {
                    BossStage = 10;
                    isArcadeMode = true;
                    break;
                }
            case 2:
                {
                    BossStage = 99;
                    isArcadeMode = false;
                    break;
                }
            default:
                {
                    Debug.LogError("Stage parameter error, Check if Parameter.Mode is set or not.");
                    break;
                }
        }
    }
}
