/**
 *  @Attack.cs
 *  @version: 1.00
 *  @author: Jesse Freeman
 *  @date: Feb 3
 *  @copyright (c) 2012 Jesse Freeman, under The MIT License (see LICENSE)
 * 
 * 	-- For use with Weekend Code Project: Unity's New 2D Workflow book --
 *
 *  This script will allow a GameObject to attack another GameObject if it
 *  has a reference to the Health Script.
 */

using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	public int attackValue = 1;
	public float attackDelay = 1f;
	public string targetTag;
	private bool canAttack;
    public bool isProjectile = false;

	// Use this for initialization
	void Start () {
		if (attackValue <= 0)
			canAttack = false;
		else
			StartCoroutine(OnAttack());

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay2D(Collision2D c)
	{
		if (c.gameObject.tag == targetTag)
		{
			if (canAttack)
				TestAttack(c.gameObject);
		}
	}

	void TestAttack(GameObject target)
	{
		if (transform.localScale.x == 1)
		{
			if (target.transform.position.x > transform.position.x)
				AttackTarget(target);
		}
		else
		{
			if (target.transform.position.x < transform.position.x)
				AttackTarget(target);
		}
		canAttack = false;
	}

	void AttackTarget(GameObject target)
	{
        Health healthComponent = target.GetComponent<Health>();
		if (healthComponent)
			healthComponent.TakeDamage(attackValue);
            if (isProjectile == true)
        {
            //Destroy object on collision if isProjectile is checked in inspector.
            Destroy(gameObject);
        }
	}

	IEnumerator OnAttack()
	{
		yield return new WaitForSeconds(attackDelay);
		canAttack = true;
		StartCoroutine(OnAttack());
	}

}
