using UnityEngine;
using System.Collections;

public class SHACK : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.localPosition = Vector3.right * Random.Range(100, 200);
	}
}
