using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;


public class GameOver : MonoBehaviour
{
    public GameObject gamoverUI;

    private Dictionary<Collider, float> contact = new Dictionary<Collider, float>();
    

    void OnTriggerEnter(Collider other)
    {
        contact.Add(other, Time.time);
    }
    /*
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
    */
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
        if (relativePosition.y > 0)
        {
            Time.timeScale = 0;
            gamoverUI.SetActive(true);
        }
    }
}