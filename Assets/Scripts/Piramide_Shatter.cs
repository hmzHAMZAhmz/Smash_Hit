using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piramide_Shatter : MonoBehaviour

{
    public GameObject shatteredObject;
    GameObject Piramide;
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("destructive"))
        {
            //int objectIndex = Random.Range(0, shatteredObject.Length);
            Piramide = Instantiate(shatteredObject, transform.position, Quaternion.Euler(90, 0, 0));
            Piramide.transform.Rotate(90, 0, 0, Space.Self);
            Destroy(gameObject);
        }
    }
}
