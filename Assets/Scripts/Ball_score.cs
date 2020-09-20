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

 
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Crown"))
           {
            cameraCharacter.winText.gameObject.SetActive(true);
            cameraCharacter.isGamePause = true;
        } 
        if (other.gameObject.CompareTag("hitobstacle"))
        {
            Destroy(other.gameObject);
            cameraCharacter.ballCount += 3;
        }
    }
}

