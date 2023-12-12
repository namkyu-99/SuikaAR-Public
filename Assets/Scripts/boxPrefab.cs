using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxPrefab : MonoBehaviour
{
    GameOver gameOverListner;

    void Start()
    {
        gameOverListner = transform.GetComponentInChildren<GameOver>();
        gameOverListner.gameoverUI = GameObject.Find("Canvas").transform.Find("Popup00_WhiteCustom").gameObject;
        gameOverListner.firebase = GameObject.Find("Firebase").GetComponent<FirebaseInit>();
        gameOverListner.spawnPointer = GameObject.Find("spawnPointer");
        gameOverListner.MotionInteraction = GameObject.Find("MotionInteraction");
        gameOverListner.gameSystem = GameObject.Find("GameSystem");
        gameOverListner.gameOver_1 = GameObject.Find("gameOver_1").GetComponent<AudioSource>();
        gameOverListner.gameOver_2 = GameObject.Find("gameOver_2").GetComponent<AudioSource>();
    }
}
