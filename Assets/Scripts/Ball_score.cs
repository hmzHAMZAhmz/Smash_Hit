using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_score : MonoBehaviour
{
    Camera_Man cameraCharacter;

    private void Start()
    {
        cameraCharacter = Camera.main.GetComponent<Camera_Man>();
        GameObject.Find("doorbutton");

    }

    private void Update()
    {
        if (transform.position.z < Camera.main.transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("hitobstacle"))
        {
            Destroy(collision.gameObject);
            cameraCharacter.ballCount += 3;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Crown"))
        {
            cameraCharacter.LevelUp();
        }
    }
}

