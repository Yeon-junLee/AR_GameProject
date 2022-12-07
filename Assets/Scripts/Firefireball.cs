using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARKit;

public class Firefireball : MonoBehaviour
{
    public GameObject Fireball_red;
    public GameObject Fireball_blue;
    public GameObject Fireball_turquoise;

    private ChooseManager choosemanager = null;
    private LifeManagerScript lifemanager = null;

    public Transform arCamera;
    private float power = 30.0f;

    AudioSource audioSource;
    void Start()
    {
        GameObject cmObject = GameObject.Find("ChooseManager");
        choosemanager = cmObject.GetComponent<ChooseManager>();

        GameObject lmObject = GameObject.Find("LifeManager");
        lifemanager = lmObject.GetComponent<LifeManagerScript>();

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (lifemanager.GameOver == true)
            return;

        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
            return;

        if (choosemanager.Fire_red == false && choosemanager.Fire_blue == false && choosemanager.Fire_tur == false)
            return;

        if (choosemanager.Fire_red == true && touch.phase == TouchPhase.Began)
        {

            GameObject fireball_red = Instantiate(Fireball_red, arCamera.position, arCamera.rotation) as GameObject;
            fireball_red.GetComponent<Rigidbody>().velocity = (arCamera.forward * power);

            audioSource.Play();
        }
        else if (choosemanager.Fire_blue == true && touch.phase == TouchPhase.Began)
        {

            GameObject fireball_blue = Instantiate(Fireball_blue, arCamera.position, arCamera.rotation) as GameObject;
            fireball_blue.GetComponent<Rigidbody>().velocity = (arCamera.forward * power);

            audioSource.Play();
        }
        else if (choosemanager.Fire_tur == true && touch.phase == TouchPhase.Began)
        {

            GameObject fireball_tur = Instantiate(Fireball_turquoise, arCamera.position, arCamera.rotation) as GameObject;
            fireball_tur.GetComponent<Rigidbody>().velocity = (arCamera.forward * power);

            audioSource.Play();
        }
    }
}