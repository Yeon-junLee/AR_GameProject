using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballManager : MonoBehaviour
{
    public float timeMax = 3.0f;
    private float time = 0.0f;
    //public Transform arCamera;
    public float power = 40.0f;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        //gameObject.GetComponent<Rigidbody>().velocity = (arCamera.forward * power);

        

        time += Time.deltaTime;
        if(timeMax <= time)
        {
            Destroy(gameObject);
        }
    }
}
