using UnityEngine;
using System.Collections;

public class frog_MonsterManager : MonoBehaviour {
    public static frog_MonsterManager instance;

    public bool isNomonster = true;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Debug.LogError("why is there two SoundManager instance?!");
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isNomonster)
        {
            GameObject monster = (GameObject)Instantiate(Resources.Load("monster"));
            frog_Monster data = monster.GetComponent<frog_Monster>();
            data.Hp = 50 * frog_Stagedata.instance.level;
            data.CDspeed = Random.Range(1f, 6f);
            data.atk = Mathf.FloorToInt(100 / (6 - data.CDspeed));
        }
	}
}
