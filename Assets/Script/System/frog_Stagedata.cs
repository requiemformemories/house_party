using UnityEngine;
using System.Collections;

public class frog_Stagedata : MonoBehaviour {
    public static frog_Stagedata instance;
    public int level;
    public int Score;
    public int combo;
    public bool isFever;
    public int monster;
    public int Hited;
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
        isFever = false;
        combo = 0;
        level = 1;
        Score = 0;
        monster = 0;
        Hited = 0;

    }

}
