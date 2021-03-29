using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Around : MonoBehaviour {
    //Code is reused from AirPort Sim Recreation.
    
    //Initializing variables
    public List<Transform> wayPointPathing;
    float speed = 5f;
    int currentPoint = 0;
    Vector3 pos;

    Rigidbody2D gameObjectBody;
    // Use this for initialization
    void Start () {

        gameObjectBody = GetComponent<Rigidbody2D>();
        //Making each plane kinematic
        gameObjectBody.isKinematic = true;

    }
	
	// Update is called once per frame
	void Update () {

        //Checking of position is not equal to the next waypoint
        if (transform.position != wayPointPathing[currentPoint].position)
        {
            //Move to waypoint
            pos = Vector3.MoveTowards(transform.position, wayPointPathing[currentPoint].position,
                                              speed * Time.deltaTime);

            gameObjectBody.MovePosition(pos);
        }
        else
        {
            //Move to the next wayPoint
            currentPoint = (currentPoint + 1) % wayPointPathing.Count;

        }



    }
}
