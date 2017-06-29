using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.RotateAroundLocal(Vector3.forward, -135.0f * Time.deltaTime);

        transform.Rotate(Vector3.forward, -135.0f * Time.deltaTime, Space.Self);
	}
}
