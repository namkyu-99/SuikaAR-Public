using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Debugger : MonoBehaviour
{
    public TextMeshProUGUI Log;

    public void addScore()
    {
        Score.UpdateScore("watermelon");
    }
}
