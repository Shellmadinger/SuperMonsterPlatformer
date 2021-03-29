/**
 *  @Health.cs
 *  @version: 1.00
 *  @author: Jesse Freeman
 *  @date: Feb 3
 *  @copyright (c) 2012 Jesse Freeman, under The MIT License (see LICENSE)
 * 
 * 	-- For use with Weekend Code Project: Unity's New 2D Workflow book --
 *
 *  This script will manage the health of an GameObject and alows you to
 *  take damage as well as display another GameObject when killed.
 */
using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
		public int maxHealth = 10;
		public int health = 10;
		public GameObject deathInstance = null;
		public Vector2 deathInstanceOffset = new Vector2 (0, 0);

		void Start ()
		{
				health = maxHealth;
		}

		public void TakeDamage (int value)
		{
				Debug.Log ("Take Damage " + value);
				health -= value;
		
				if (health <= 0) {
						OnKill ();
				}
		}
	
		public void OnKill ()
		{
				if (deathInstance) {
						Vector3 position = gameObject.transform.position;
						Instantiate (deathInstance, new Vector3 (position.x + deathInstanceOffset.x, position.y + deathInstanceOffset.y, position.z), Quaternion.identity);
				}

				Destroy (gameObject);
		}

}
