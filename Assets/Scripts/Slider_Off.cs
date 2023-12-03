using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Off : MonoBehaviour
{
    public Slider slider;
    public Image handle;
    public Sprite on, off;

    // Update is called once per frame
    void Update()
    {
        if(slider.value == 0.0f)
            handle.sprite = off;
        else
            handle.sprite = on;
    }
}
