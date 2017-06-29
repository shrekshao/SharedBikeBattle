using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanFollowCamera : MonoBehaviour {

    [SerializeField] Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 t = transform.position;
        t.x = target.transform.position.x;

        transform.position = t;
    }
}
