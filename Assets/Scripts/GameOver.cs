using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;


public class GameOver : MonoBehaviour
{
    public GameObject gameoverUI;
    public FirebaseInit firebase;

    public GameObject spawnPointer;
    public GameObject MotionInteraction;
    public GameObject gameSystem;

    public AudioSource gameOver_1, gameOver_2;

    private Dictionary<Collider, float> contact = new Dictionary<Collider, float>();

    bool isGameOver = false;
    
    void OnTriggerEnter(Collider other)
    {
        contact.Add(other, Time.time);
    }
    // void OnTriggerStay(Collider other)
    // {
    //     if (contact.ContainsKey(other))
    //     {
    //         float current = Time.time;
    //         if (current - contact[other] >= 3f)
    //         {
    //             Time.timeScale = 0;
    //             gameoverUI.SetActive(true);
    //         }
    //     }
    // }
    
    void OnTriggerExit(Collider other)
    {
        contact.Remove(other);

        // 접촉한 오브젝트의 위치 정보를 얻음
        Vector3 otherPosition = other.transform.position;

        // 자신의 위치 정보를 얻음
        Vector3 selfPosition = transform.position;

        // 상대적인 위치 벡터를 계산
        Vector3 relativePosition = otherPosition - selfPosition;

        // 접촉한 오브젝트의 이동 방향이 위쪽인지 아래쪽인지를 확인
        if (relativePosition.y > 0 && !isGameOver)
        {
            gameOver();
        }
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        gameoverUI.SetActive(true);
        firebase.AddScore(PlayerPrefs.GetString("Nickname", "Unknown"), Score.GetCurrentScore());
        // firebase.LoadData();
        gameOver_1.Play();
        gameOver_2.Play();
        isGameOver = true;

        spawnPointer.SetActive(false);
        MotionInteraction.SetActive(false);
        gameSystem.SetActive(false);
    }
}