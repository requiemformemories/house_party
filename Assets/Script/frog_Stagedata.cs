using UnityEngine;
using System.Collections;

public class frog_Stagedata : MonoBehaviour {
    public static frog_Stagedata instance;
    public int level;

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
	void Update () {
	
	}
}
