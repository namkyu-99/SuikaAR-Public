using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmCreator : MonoBehaviour
{
    public GameObject BGM;
    
    void Start()
    {
        if(GameObject.FindGameObjectsWithTag("BGM").Length == 0)
            Instantiate(BGM);
        Destroy(this.gameObject);
    }
}
