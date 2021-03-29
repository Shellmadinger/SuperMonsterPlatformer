/**
 *  @CameraFollow.cs
 *  @version: 1.00
 *  @author: Jesse Freeman
 *  @date: Feb 3
 *  @copyright (c) 2012 Jesse Freeman, under The MIT License (see LICENSE)
 * 
 * 	-- For use with Weekend Code Project: Unity's New 2D Workflow book --
 *
 *  This script will make the Camera GameObject follow a target GameObject.
 */

using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject target;
    private Transform targetPos;


    // Use this for initialization
    void Start() {
        targetPos = target.transform;
    }

    // Update is called once per frame
    void LateUpdate() {
        if (targetPos) {
            transform.position = new Vector3(targetPos.position.x, targetPos.position.y, transform.position.z);
        }
    }

}
