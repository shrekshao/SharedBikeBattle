using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0f, 0f, -135.0f * Time.deltaTime);
	}
}
