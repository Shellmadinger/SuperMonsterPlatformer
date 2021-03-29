using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Projectile_Automatic : MonoBehaviour {
    //Code is for firing projectile based on Time intervals
    //initializing variables
    public GameObject fireBall;
    public GameObject fireBallGameObject;
    bool shoot;
    float move;

    private void Start()
    {
        //Spawn projectile every 4 seconds
        InvokeRepeating("CreateProjectile", 1, 4f);
    }

    void CreateProjectile()
    {
        //Instantiates bullet when if statement triggers
        Instantiate(fireBall, fireBallGameObject.transform.position + new Vector3(0.5f, 0.21f, 0f), new Quaternion());
    }
}
