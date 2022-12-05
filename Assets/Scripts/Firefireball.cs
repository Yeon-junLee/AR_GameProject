using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Firefireball : MonoBehaviour
{
    public GameObject Fireball_red;
    public GameObject Fireball_blue;
    public GameObject Fireball_turquoise;

    private ChooseManager choosemanager = null;
    private LifeManager lifemanager = null;

    private Vector3 touchedPos;
    public Camera cam;
    private float power = 5.0f;

    Vector3 vec = new Vector3(0f, 0f, 0.05f);

    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    ARRaycastManager m_RaycastManager;

    AudioSource audioSource;
    void Start()
    {
        GameObject cmObject = GameObject.Find("ChooseMangaer");
        choosemanager = cmObject.GetComponent<ChooseManager>();

        GameObject lmObject = GameObject.Find("LifeMangaer");
        lifemanager = lmObject.GetComponent<LifeManager>();

        audioSource = GetComponent<AudioSource>();

        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifemanager.GameOver)
            return;

        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
            return;

        /*Vector3 touchPos = new Vector3(touch.position.x, touch.position.y, 0);
        touchedPos = cam.transform.position; //Camera.main.ScreenToWorldPoint(touchPos + vec);*/

        if(m_RaycastManager.Raycast(touch.position, m_Hits))
        {
            Pose hitPose = m_Hits[0].pose;

            if (choosemanager.Fire_red == false && choosemanager.Fire_blue == false && choosemanager.Fire_tur == false)
                return;

            if (choosemanager.Fire_red == true)
            {
                GameObject fireball_red = Instantiate(Fireball_red);
                fireball_red.transform.position = hitPose.position;

                Vector3 direction = cam.transform.localRotation * Vector3.forward + new Vector3(0.0f, 0.1f, 0.0f);
                fireball_red.GetComponent<Rigidbody>().velocity = direction * power;

                audioSource.Play();
            }
            else if (choosemanager.Fire_blue == true)
            {
                GameObject fireball_blue = Instantiate(Fireball_blue);
                fireball_blue.transform.position = hitPose.position;

                Vector3 direction = cam.transform.localRotation * Vector3.forward + new Vector3(0.0f, 0.1f, 0.0f);
                fireball_blue.GetComponent<Rigidbody>().velocity = direction * power;

                audioSource.Play();
            }
            else if (choosemanager.Fire_blue == true)
            {
                GameObject fireball_tur = Instantiate(Fireball_turquoise);
                fireball_tur.transform.position = hitPose.position;

                Vector3 direction = cam.transform.localRotation * Vector3.forward + new Vector3(0.0f, 0.1f, 0.0f);
                fireball_tur.GetComponent<Rigidbody>().velocity = direction * power;

                audioSource.Play();
            }
        }

        
    }
}
