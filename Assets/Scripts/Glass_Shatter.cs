using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass_Shatter : MonoBehaviour
{
    public GameObject[] shatteredObject;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("destructive")) 
        {
            int objectIndex = Random.Range(0, shatteredObject.Length);
            Instantiate(shatteredObject[objectIndex], transform.position, shatteredObject[objectIndex].transform.rotation);
            Destroy(gameObject);
        }
    }
}
