using UnityEngine;
using System.Collections;

public class EJ_Cursor : MonoBehaviour {

	float iCounter;
	// Use this for initialization
	void Start () {
		iCounter = 3;
	}
	
	// Update is called once per frame
	void Update () {

	}

//	void OnTriggerEnter (BoxCollider c) {
//
//		if(c.gameObject.name == "Texture"){
//			Debug.Log("Box went through!");
//		}
//	}
	void OnTriggerEnter(BoxCollider c){
		EJ_ButtonEvent myBe = c.gameObject.GetComponent<EJ_ButtonEvent>();
		myBe.OnTrigger(); Debug.Log ("Test!");
	}

	void OnTriggerStay (BoxCollider c) {
		iCounter -= Time.deltaTime;
		EJ_ButtonEvent myBe;
		if (iCounter < 0) {
			myBe = c.gameObject.GetComponent<EJ_ButtonEvent>();
			myBe.OnClick();
		}
	}

	void OnTriggerExit(BoxCollider c) {
		EJ_ButtonEvent myBe = c.gameObject.GetComponent<EJ_ButtonEvent> ();
		myBe.OnExit();
		iCounter = 3;
	}
}
