using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("BGM", 0.5f);
    }
}
