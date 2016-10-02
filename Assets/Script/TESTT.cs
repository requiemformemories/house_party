using UnityEngine;
using System.Collections;

public class TESTT : MonoBehaviour {
    void OnTriggerEnter(Collider c)
    {
        Debug.Log("DD");
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            gameObject.transform.localPosition+=Vector3.up;
        }
	}
}
