using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;


public class GameOver2 : MonoBehaviour
{
    public GameObject gamoverUI;

    private Dictionary<Collider, float> contact = new Dictionary<Collider, float>();


    void OnTriggerEnter(Collider other)
    {
        contact.Add(other, Time.time);
    }
    
    void OnTriggerStay(Collider other)
    {
        if (contact.ContainsKey(other))
        {
            float current = Time.time;
            if (current - contact[other] >= 3f)
            {
                Time.timeScale = 0;
                gamoverUI.SetActive(true);
            }
        }

    }
    
}