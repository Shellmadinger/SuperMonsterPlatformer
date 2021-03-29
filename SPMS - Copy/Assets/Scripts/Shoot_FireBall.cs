using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_FireBall : MonoBehaviour {

    public GameObject fireBall;
    public GameObject fireBallGameObject;
    bool shoot;
    float move;
    bool limit = false;
    int shotCounter = 0;

    private void Awake()
    {
        StartCoroutine(Reset());
    }

    // Update is called once per frame
    void Update() {
        shoot = Input.GetButtonDown("Fire1");

        if (shoot && limit == false)
        {
            //Instantiates bullet when if statement triggers
            Instantiate(fireBall, fireBallGameObject.transform.position + new Vector3(0.5f, 0.21f, 0f), new Quaternion());
            shotCounter++;
        }

        if (shotCounter == 3)
        {
            limit = true;
            
        }

    }

    IEnumerator Reset()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            shotCounter = 0;
            limit = false;
        }
        
    }

}
