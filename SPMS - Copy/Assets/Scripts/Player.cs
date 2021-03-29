/**
 *  @Player.cs
 *  @version: 1.00
 *  @author: Jesse Freeman
 *  @date: Feb 3
 *  @copyright (c) 2012 Jesse Freeman, under The MIT License (see LICENSE)
 * 
 * 	-- For use with Weekend Code Project: Unity's New 2D Workflow book --
 *
 *  This script will allow you to move a GameObject, idealy the player,
 *  via the keyboard and the mouse. This will slide GameObject forward
 *  based on the direction of the input.
 */

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //Initialize Variables
     public float speed = 200;
     public float verticalSpeed = 10;
     float playerJump;
     float xAxis;
     bool grounded = false;
     public Transform lineCastStart;
     public Transform lineCastEnd;
     bool jump;
     bool isFacingRight = true;
     Rigidbody2D rigidbody2DComponent;

      void Awake() {
        //Getting RigidBody
          rigidbody2DComponent = GetComponent<Rigidbody2D>();
      }

      // Update is called once per frame
      void Update()
      {
        //Function calls in Update
        CheckPlayerJump();
        Flip();
        
      }

      private void FixedUpdate()
      {
        //Player movement in FixedUpdate
        PlayerMovement();
      }

      void PlayerMovement()
      {
      
        if (jump)
        {
            //Make player jump when space is pressed
            rigidbody2DComponent.AddForce(new Vector3(0, verticalSpeed), ForceMode2D.Impulse);
            jump = false;
        }

        //return 0 if xAxis is 0
        if (xAxis == 0) return;

        //Force for horizontal movement
        rigidbody2DComponent.AddForce(new Vector2(xAxis * speed, verticalSpeed));
      }

     void CheckPlayerJump()
     {
        //Check to see if player is on the ground
        //Similar to how you check the ground for jumping animations
        Debug.DrawLine(lineCastStart.position, lineCastEnd.position, Color.green);

        int groundLayerMask = 1 << LayerMask.NameToLayer("Platform");
        //grounded is true if the line goes through the ground layer
        grounded = (Physics2D.Linecast(lineCastStart.position, lineCastEnd.position, groundLayerMask)) ? true : false;

        xAxis = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && grounded)
        {
            //Player jumps only when they are on the ground
            jump = true;
        }
     }

    public void Flip()
    {
        //Flip player sprite based on xAxis
        if(xAxis<0 && isFacingRight)
        {
            transform.localScale = new Vector2(-0.6485531f, 0.6485531f);
            isFacingRight = false;
        }
        else if(xAxis>0 && !isFacingRight)
        {
            transform.localScale = new Vector2(0.6485531f, 0.6485531f);
            isFacingRight = true;
        }
    }
    
}
