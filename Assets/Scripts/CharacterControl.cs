using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    [SerializeField]
    GameObject paddle;

    [SerializeField]
    GameObject wheelF;

    [SerializeField]
    GameObject wheelB;


    Animator m_animator;
    Rigidbody m_rigidBody;


    //Vector3 bikeVelocity = new Vector3();

    float maxSpeedHorizontal = 10f;
    float maxSpeedVertical = 3f;

	// Use this for initialization
	void Start () {
        m_animator = GetComponent<Animator>();

        m_rigidBody = GetComponent<Rigidbody>();
	}


	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space))
        {
            m_animator.SetTrigger("attack");
        }

        //float hspeed = Input.GetAxis("Horizontal") * 3f;
        //transform.position += Vector3.right * Time.deltaTime * hspeed;

        ////Debug.Log(hspeed);
        //if (Mathf.Abs(hspeed) > 0.001f)
        //{
        //    transform.localScale = new Vector3(Mathf.Sign(hspeed), 1f, 1f);
        //}


        float hacc = Input.GetAxis("Horizontal");
        float vacc = Input.GetAxis("Vertical") * 0.3f;

        Vector3 bikeVelocity = m_rigidBody.velocity;

        bikeVelocity.x += hacc;
        bikeVelocity.z += vacc;

        bikeVelocity.x = Mathf.Clamp(bikeVelocity.x, -maxSpeedHorizontal, maxSpeedHorizontal);
        bikeVelocity.z = Mathf.Clamp(bikeVelocity.z, -maxSpeedVertical, maxSpeedVertical);

        m_rigidBody.velocity = bikeVelocity;


        // bike facing
        if (Mathf.Abs(bikeVelocity.x) > 0.001f)
        {
            //transform.localScale = new Vector3(Mathf.Sign(bikeVelocity.x), 1f, 1f);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Mathf.Sign(bikeVelocity.x), transform.localScale.y, transform.localScale.z);
        }

        float r = bikeVelocity.x * 60f * Time.deltaTime;
        wheelF.transform.Rotate(Vector3.back, r, Space.Self);
        wheelB.transform.Rotate(Vector3.back, r, Space.Self);
        paddle.transform.Rotate(Vector3.back, r, Space.Self);

    }
}
