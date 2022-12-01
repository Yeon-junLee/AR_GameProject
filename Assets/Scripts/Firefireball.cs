using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefireball : MonoBehaviour
{
    public GameObject Fireball_red;
    public GameObject Fireball_blue;
    public GameObject Fireball_turquoise;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
            return;

        
    }
}
