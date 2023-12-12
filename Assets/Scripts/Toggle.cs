using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
    public GameObject on, off;
    public bool isOn = true;

    void Start()
    {
        isOn = System.Convert.ToBoolean(PlayerPrefs.GetInt("Vibration", 1));

        if(isOn)
        {
            on.SetActive(true);
            off.SetActive(false);
        }
        else
        {
            on.SetActive(false);
            off.SetActive(true);
        }
    }

    public void OnClick()
    {
        isOn = !isOn;
        PlayerPrefs.SetInt("Vibration", System.Convert.ToInt16(isOn));

        if(isOn)
        {
            on.SetActive(true);
            off.SetActive(false);
            Handheld.Vibrate();
        }
        else
        {
            on.SetActive(false);
            off.SetActive(true);
        }
    }
}