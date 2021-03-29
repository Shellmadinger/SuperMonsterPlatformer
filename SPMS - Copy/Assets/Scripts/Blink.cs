/**
 *  @Blink.cs
 *  @version: 1.00
 *  @author: Jesse Freeman
 *  @date: Feb 3
 *  @copyright (c) 2012 Jesse Freeman, under The MIT License (see LICENSE)
 * 
 * 	-- For use with Weekend Code Project: Unity's New 2D Workflow book --
 *
 *  This script will hide and show a GameObject based on a set time dealy.
 */
using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {
    public float delay = .5f;

    SpriteRenderer spriteRendererComponent;

    void Awake() {
        spriteRendererComponent = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start() {
        StartCoroutine(OnBlink());
    }

    IEnumerator OnBlink() {
        yield return new WaitForSeconds(delay);

        float alpha = spriteRendererComponent.color.a;

        float newAlpha = 0f;

        if (alpha != 1) {
            newAlpha = 1f;
        }

        spriteRendererComponent.color = new Color(1, 1, 1, newAlpha);

        StartCoroutine(OnBlink());
    }
}
