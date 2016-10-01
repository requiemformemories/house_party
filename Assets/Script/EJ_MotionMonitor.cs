using UnityEngine;
using System.Collections;

public class EJ_MotionMonitor : MonoBehaviour {

	


	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame 
	void Update () {
		//Rotating a camera using the gyroscope
		//根據玩家的手機的轉向移動視角
		transform.Rotate (Input.gyro.rotationRateUnbiased.x, 
			-Input.gyro.rotationRateUnbiased.y, Input.gyro.rotationRate.z);
	}
}
