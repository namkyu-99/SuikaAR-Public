using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
    public GameObject on, off;
    public bool isOn = true;

    public void OnClick()
    {
        isOn = !isOn;

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
}