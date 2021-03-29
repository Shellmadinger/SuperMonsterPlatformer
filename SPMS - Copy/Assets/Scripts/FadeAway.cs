/**
 *  @FadeAway.cs
 *  @version: 1.00
 *  @author: Jesse Freeman
 *  @date: Feb 3
 *  @copyright (c) 2012 Jesse Freeman, under The MIT License (see LICENSE)
 * 
 * 	-- For use with Weekend Code Project: Unity's New 2D Workflow book --
 *
 *  This script will fade a GameObject to 0 alpha and destroy it automatically.
 */

using UnityEngine;
using System.Collections;

public class FadeAway : MonoBehaviour {
    public bool autoDistroy = true;
    public float delay = 2.0f;


    SpriteRenderer spriteRendererComponent;

    void Awake() {
        spriteRendererComponent = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start() {
        StartCoroutine(FadeTo(0.0f, 1.0f));
    }

    IEnumerator FadeTo(float aValue, float aTime) {
        yield return new WaitForSeconds(delay);

        float alpha = transform.GetComponent<Renderer>().material.color.a;
        for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / aTime) {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            spriteRendererComponent.color = newColor;

            if (newColor.a <= 0.05) {
                Destroy(gameObject);
            }
            yield return null;
        }

    }
}
