using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefireball : MonoBehaviour
{
    public GameObject Fireball_red;
    public GameObject Fireball_blue;
    public GameObject Fireball_turquoise;

    private ChooseManager choosemanager = null;

    private Vector3 touchedPos;

    public Camera cam;

    private float power = 5.0f;
    void Start()
    {
        GameObject cmObject = GameObject.Find("ChooseMangaer");
        choosemanager = cmObject.GetComponent<ChooseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
            return;

        touchedPos = Camera.main.ScreenToWorldPoint(touch.position);

        if (choosemanager.Fire_red == false && choosemanager.Fire_blue == false && choosemanager.Fire_tur == false)
            return;

        if(choosemanager.Fire_red == true)
        {
            GameObject fireball_red = Instantiate(Fireball_red);
            fireball_red.transform.position = touchedPos;

            Vector3 direction = cam.transform.localRotation * Vector3.forward + new Vector3(0.0f, 1.5f, 0.0f);
            fireball_red.GetComponent<Rigidbody>().velocity = direction * power;
        }
        else if (choosemanager.Fire_blue == true)
        {
            GameObject fireball_blue = Instantiate(Fireball_blue);
            fireball_blue.transform.position = touchedPos;

            Vector3 direction = cam.transform.localRotation * Vector3.forward + new Vector3(0.0f, 1.5f, 0.0f);
            fireball_blue.GetComponent<Rigidbody>().velocity = direction * power;
        }
        else if (choosemanager.Fire_blue == true)
        {
            GameObject fireball_tur = Instantiate(Fireball_turquoise);
            fireball_tur.transform.position = touchedPos;

            Vector3 direction = cam.transform.localRotation * Vector3.forward + new Vector3(0.0f, 1.5f, 0.0f);
            fireball_tur.GetComponent<Rigidbody>().velocity = direction * power;
        }
    }
}
