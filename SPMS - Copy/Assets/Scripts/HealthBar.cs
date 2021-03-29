/**
 *  @ControlsUI.cs
 *  @version: 1.00
 *  @author: Jesse Freeman
 *  @date: Feb 3
 *  @copyright (c) 2012 Jesse Freeman, under The MIT License (see LICENSE)
 * 
 * 	-- For use with Weekend Code Project: Unity's New 2D Workflow book --
 *
 *  This script Visualizes the health value on a GameObject with the
 *  Health script attached to it.
 */
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    Health healthComponent;
    public Image healthImage;


    void Awake() {
        healthComponent = GetComponent<Health>();
    }
    void Start() {
        healthImage.rectTransform.localScale = new Vector3(1, 1, 1);
    }

    void Update() {
        float percent = healthComponent.health / (float)healthComponent.maxHealth;
        healthImage.rectTransform.localScale = new Vector3(percent, 1, 1);
    }

}
