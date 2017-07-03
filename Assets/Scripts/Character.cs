using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    Animator m_animator;
    Rigidbody m_rigidBody;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        float hacc = Input.GetAxis("Horizontal");
        float vacc = Input.GetAxis("Vertical");

        if (Mathf.Abs(hacc) > 0 || Mathf.Abs(vacc) > 0)
        {
            m_animator.SetBool("walking", true);
        }
        else
        {
            m_animator.SetBool("walking", false);
        }

        transform.position += Vector3.right * hacc * Time.deltaTime;

        if (Mathf.Abs(hacc) > 0.001f)
        {
            //transform.localScale = new Vector3(Mathf.Sign(bikeVelocity.x), 1f, 1f);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Mathf.Sign(hacc), transform.localScale.y, transform.localScale.z);
        }
    }
}
