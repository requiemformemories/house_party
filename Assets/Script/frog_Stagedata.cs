using UnityEngine;
using System.Collections;

public class frog_Stagedata : MonoBehaviour {
    public static frog_Stagedata instance;
    public int level;
    public int playerHp;
    public int combo;
    public bool isFever;
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
        combo = 0;
        level = 1;
        playerHp = 1000;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
