using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    //Initializing variables
    Vector3 startPoint = new Vector3(5.4f, 1f, 0);
    Vector3 endPoint = new Vector3(16.9f, 1f, 0);
    public GameObject spawnPoint;
    public GameObject missle;
    public float speed = 10;
	// Use this for initialization
	void Start () {
        //Spawn a homing missile every 4 seconds
        InvokeRepeating("SpawnMissiles", 1, 4f);
	}
	
	// Update is called once per frame
	void Update () {
        //Lerp between two points
        transform.position = Vector3.Lerp(startPoint, endPoint, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }

    void SpawnMissiles()
    {
        //Instantiating missile
        Instantiate(missle, spawnPoint.transform.position + new Vector3(0.5f, 0.21f, 0f), new Quaternion());
    }
    
}
