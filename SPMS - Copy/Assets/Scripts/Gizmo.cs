/**
 *  @Gizmo.cs
 *  @version: 1.00
 *  @author: Jesse Freeman
 *  @date: Feb 3
 *  @copyright (c) 2012 Jesse Freeman, under The MIT License (see LICENSE)
 * 
 * 	-- For use with Weekend Code Project: Unity's New 2D Workflow book --
 *
 *  This script will display a colored box around any GameObject it is
 *  attached to. It also has logic for storing additional target GameObjects
 *  and returning a random GameObject from the target list.
 */

using UnityEngine;
using System.Collections.Generic;

public class Gizmo : MonoBehaviour {
	public Color color = new Color(0.985f, 0.022f, 0.022f, 0.2f);
	public List<GameObject> targets = new List<GameObject>();
	public Vector3 size = new Vector3(1, 1, 0);

	void OnDrawGizmos()
	{
		Gizmos.color = color;
		Gizmos.DrawCube(transform.position, size);
		
		if (targets.Count > 0)
		{
			for (int i = 0; i < targets.Count; i++)
			{
				Gizmos.DrawLine(transform.position, targets[i].transform.position);
			}
		}
		
	}
	
	public GameObject GetRandomTarget()
	{
		if (targets.Count == 0)
			return null;
		
		return targets[Random.Range(0, targets.Count)];
	}
	
	public GameObject GetTargetAt(int index)
	{
		if (targets.Count == 0)
			return null;
		
		return targets[index];
	}

}
