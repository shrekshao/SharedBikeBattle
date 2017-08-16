using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour {

    public Transform sitPivot;
    //public GameObject paddle;
    public Anima2D.IkLimb2D Lfoot;
    public Anima2D.IkLimb2D Rfoot;
    public Anima2D.IkLimb2D Lhand;

    [SerializeField]
    GameObject paddle;

    [SerializeField]
    GameObject wheelF;

    [SerializeField]
    GameObject wheelB;


    Rigidbody m_rigidBody;

    float maxSpeedHorizontal = 10f;
    float maxSpeedVertical = 3f;

    // Use this for initialization
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bikeVelocity = m_rigidBody.velocity;
        float r = bikeVelocity.x * 60f * Time.deltaTime;
        wheelF.transform.Rotate(Vector3.back, r, Space.Self);
        wheelB.transform.Rotate(Vector3.back, r, Space.Self);
        paddle.transform.Rotate(Vector3.back, r, Space.Self);
    }

    public void Ride(float hacc, float vacc)
    {
        Vector3 bikeVelocity = m_rigidBody.velocity;

        //vacc = Mathf.Clamp(Mathf.Abs(hacc) - 0.05f, 0f, 1f ) * vacc;

        bikeVelocity.x += hacc;
        bikeVelocity.z += vacc;

        bikeVelocity.x = Mathf.Clamp(bikeVelocity.x, -maxSpeedHorizontal, maxSpeedHorizontal);
        //bikeVelocity.z = Mathf.Clamp(bikeVelocity.z, -maxSpeedVertical, maxSpeedVertical);
        float hvClampFactor = Mathf.Clamp(0.2f * ( Mathf.Abs(bikeVelocity.x) - 0.2f), 0f, 1f);
        bikeVelocity.z = Mathf.Clamp(bikeVelocity.z, -maxSpeedVertical * hvClampFactor, maxSpeedVertical * hvClampFactor);

        m_rigidBody.velocity = bikeVelocity;


        // bike facing
        if (Mathf.Abs(bikeVelocity.x) > 0.001f)
        {
            //transform.localScale = new Vector3(Mathf.Sign(bikeVelocity.x), 1f, 1f);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Mathf.Sign(bikeVelocity.x), transform.localScale.y, transform.localScale.z);
        }

        
    }
}
