using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision_Scene : MonoBehaviour {

    //Purpose of code it to load a scene based on collision
    public string Scene;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //Load scene if player collides with object
            SceneManager.LoadScene(Scene);
        }
    }
}
