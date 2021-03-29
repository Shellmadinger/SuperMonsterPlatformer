/**
 *  @MoveForward.cs
 *  @version: 1.00
 *  @author: Jesse Freeman
 *  @date: Feb 3
 *  @copyright (c) 2012 Jesse Freeman, under The MIT License (see LICENSE)
 * 
 * 	-- For use with Weekend Code Project: Unity's New 2D Workflow book --
 *
 *  This script will move a GameObject forward based on the direction it
 *  is facing and its speed.
 */

using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour { 
    //Altered MoveFoward Script to work as a lerp between two points

    Vector3 pointA = new Vector3(9.26f, 2f, 0);
    Vector3 pointB = new Vector3(24.13f, 2f, 0);
    public float speed = .3f; // Speed to move the GameObject


    void Update() {
        transform.position = Vector3.Lerp(pointA, pointB, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
       
    }
}
