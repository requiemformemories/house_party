using UnityEngine;
using System.Collections;

public class LevelText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<UILabel>().text = frog_Stagedata.instance.level.ToString();
	}
}
