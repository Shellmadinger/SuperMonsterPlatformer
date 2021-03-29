/**
 *  @Spawner.cs
 *  @version: 1.00
 *  @author: Jesse Freeman
 *  @date: Feb 3
 *  @copyright (c) 2012 Jesse Freeman, under The MIT License (see LICENSE)
 * 
 * 	-- For use with Weekend Code Project: Unity's New 2D Workflow book --
 *
 *  This script will spawn new GameObjects to its own location or to a
 *  set of targets.
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public GameObject[] enemyPool;
	public float delay = 2.0f;
	public bool isActive = true;

	public Vector2 direction = new Vector2(1, 1);
	private List<GameObject> targets;
	private Gizmo parentGizmo;

	void Start () {
		parentGizmo = gameObject.GetComponent<Gizmo>();
		targets = parentGizmo.targets;
		StartCoroutine(EnemyGenerator());
	}

	IEnumerator EnemyGenerator()
	{
		if (isActive)
		{
			Transform newTransform = transform;
			
			yield return new WaitForSeconds(delay);
			
			if (targets.Count > 0)
			{
				GameObject spawnTarget  = targets[Random.Range(0, targets.Count)];
				newTransform = spawnTarget.transform;
				direction = spawnTarget.transform.localScale;
			}
			
			GameObject clone = Instantiate(enemyPool[Random.Range(0, enemyPool.Length)], newTransform.position, Quaternion.identity) as GameObject;
			clone.transform.localScale = direction;
			StartCoroutine(EnemyGenerator());
		}
	}

}
