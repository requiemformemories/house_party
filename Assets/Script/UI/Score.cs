using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindObjectOfType<frog_Stagedata>() != null)
        {
            gameObject.GetComponent<UILabel>().text = GameObject.FindObjectOfType<frog_Stagedata>().Score.ToString() ;

        }
    }
}
