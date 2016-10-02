using UnityEngine;
using System.Collections;

public class EJ_ButtonEvent : MonoBehaviour {

	public UITweener MyTween;

	public void OnTrigger(){
		MyTween.PlayForward();
	}

	public void OnClick(){
		MyTween.PlayForward();
	}

	public void OnExit(){
		MyTween.PlayReverse ();
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
