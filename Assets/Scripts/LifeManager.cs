using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeManager : MonoBehaviour
{
    public bool GameOver = false;
    private int Life = 3;

    public TextMeshProUGUI LifeText = null;
    public GameObject GMUI;
    public GameObject BackButton;

    void Start()
    {
        LifeText.text = "Life : 3";
    }

    public void SnowManHit()
    {
        Life -= 1;
        LifeText.text = "Life : " + Life.ToString();
    }

    void Update()
    {
        if(Life == 0)
        {
            GameOver = true;
            GMUI.SetActive(true);
            BackButton.SetActive(true);
        }
    }
}
