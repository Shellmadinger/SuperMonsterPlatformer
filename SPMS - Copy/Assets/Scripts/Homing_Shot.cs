using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_Shot : MonoBehaviour {
    //Initializing Variables
    public float speed = 3;
    public float rotSpeed = 200;
    GameObject target;

    Rigidbody2D rb;
    float lifeTime = 5;
	// Use this for initialization
	void Start () {

        //Finding player and getting RigidBody
        target = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();

        
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //Find distance between target and gameobject
        Vector2 pointAtTarget = ((Vector2)transform.position - (Vector2)target.transform.position).normalized;

        //Get cross product of z value
        float value = Vector3.Cross(pointAtTarget, -transform.right).z;

        //Change rotation based on value
        if (value > 0)
        {
            rb.angularVelocity = rotSpeed;
        }
        else if (value < 0)
        {
            rb.angularVelocity = -rotSpeed;
        }
        else
        {
            rb.angularVelocity = 0;
        }
        //Move missile with velocity
        rb.velocity = -transform.right * speed;
        //Destroy GameObject after lifeTime
        Destroy(gameObject, lifeTime);
    }
}
