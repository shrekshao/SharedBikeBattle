using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    Animator m_animator;
    Rigidbody m_rigidBody;
    UnityEngine.Rendering.SortingGroup m_sortingGroup;

    bool riding = false;

    Bike bike = null;

    public Anima2D.Bone2D Lfoot;
    public Anima2D.Bone2D Rfoot;
    public Anima2D.Bone2D Lhand;


    private float lastGetOnBikeTime = 0f;

    // temp for bike
    float maxSpeedHorizontal = 10f;
    float maxSpeedVertical = 3f;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_rigidBody = GetComponent<Rigidbody>();
        m_sortingGroup = GetComponent<UnityEngine.Rendering.SortingGroup>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Z))
        {
            Attack();
        }

        float hacc = Input.GetAxis("Horizontal");
        float vacc = Input.GetAxis("Vertical");

        if (!riding)
        {
            // walking
            if (Mathf.Abs(hacc) > 0 || Mathf.Abs(vacc) > 0)
            {
                m_animator.SetBool("walking", true);
            }
            else
            {
                m_animator.SetBool("walking", false);
            }

            transform.position += (3.0f * Vector3.right * hacc + Vector3.forward * vacc) * Time.deltaTime ;

            if (Mathf.Abs(hacc) > 0.001f)
            {
                //transform.localScale = new Vector3(Mathf.Sign(bikeVelocity.x), 1f, 1f);
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Mathf.Sign(hacc), transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            // riding

            if (Input.GetKeyUp(KeyCode.X))
            {
                if (lastGetOnBikeTime + 0.2f < Time.time)
                {
                    GetOffBike();
                }
                
            }
            else
            {
                bike.Ride(hacc, vacc * 0.3f);
            }

            
        }

        
    }



    void OnTriggerStay(Collider c)
    {
        if (c.CompareTag("Bike"))
        {
            if(Input.GetKeyUp(KeyCode.X))
            {
                //Debug.Log("ride bike");

                GetOnBike(c.gameObject.GetComponent<Bike>(), c.transform);
            }
        }
    }

    void GetOnBike(Bike bike, Transform bikeTransform)
    {
        lastGetOnBikeTime = Time.time;

        m_sortingGroup.enabled = false;
        transform.parent = bikeTransform;
        transform.localPosition = bike.sitPivot.localPosition;

        bike.Lfoot.enabled = true;
        bike.Lfoot.target = Lfoot;
        bike.Rfoot.enabled = true;
        bike.Rfoot.target = Rfoot;
        bike.Lhand.enabled = true;
        bike.Lhand.target = Lhand;

        riding = true;
        m_animator.SetBool("riding", true);
        this.bike = bike;

        GetComponent<Collider>().enabled = false;
    }

    void GetOffBike()
    {
        m_sortingGroup.enabled = true;
        Transform bikeTransform = transform.parent;
        transform.parent = null;
        transform.position = bikeTransform.position;

        
        //bike.Lfoot.target = null;
        bike.Lfoot.enabled = false;
        //bike.Rfoot.target = null;
        bike.Rfoot.enabled = false;
        //bike.Lhand.target = null;
        bike.Lhand.enabled = false;

        riding = false;
        m_animator.SetBool("riding", false);
        this.bike = null;

        GetComponent<Collider>().enabled = true;
    }



    void Attack()
    {
        m_animator.SetTrigger("attack");
        //m_animator.SetInteger("attackStyle", Random.Range(0, 2));
    }
}
