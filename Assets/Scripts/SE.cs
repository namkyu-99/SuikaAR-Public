using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SE", 1f);
    }
}
