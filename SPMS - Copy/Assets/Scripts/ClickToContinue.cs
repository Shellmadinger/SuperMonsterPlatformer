/**
 *  @ClickToContinue.cs
 *  @version: 1.00
 *  @author: Jesse Freeman
 *  @date: Feb 3
 *  @copyright (c) 2012 Jesse Freeman, under The MIT License (see LICENSE)
 * 
 * 	-- For use with Weekend Code Project: Unity's New 2D Workflow book --
 *
 *  This script will load a new Scene when the user clicks the mouse.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToContinue : MonoBehaviour {

	public string scene;
	private bool loadLock = false;
	
	void Update () {
		if(Input.GetMouseButtonDown(0) && !loadLock)
		{
			LoadScene();
		}
	}

	void LoadScene()
	{
		if (scene == null)
			return;

		loadLock = true; 
        SceneManager.LoadScene(scene);
	}
}
