using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall_Behaviour : MonoBehaviour {
    //Controling fireball movement and lifetime happens here
    //Code here is reused from Stock Adventure (Bullet), with added lifetime and check for left facing objects
    //Initialize Variables
    public float speed;
    public float lifeTime = 2;
    public bool isFacingLeft = false;


    void Update()
    {
        if (isFacingLeft == true)
        {
            speed = -2;
        }
        //Move fireball based off of Time.deltaTime
        transform.Translate(new Vector3(speed * Time.deltaTime, 0f));

       
        //Destroy fireball when lifetime is reached
        Destroy(gameObject, lifeTime);

    }

}
