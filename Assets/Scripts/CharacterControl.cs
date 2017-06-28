using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    Animator m_animator;

	// Use this for initialization
	void Start () {
        m_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space))
        {
            m_animator.SetTrigger("attack");
        }
	}
}
