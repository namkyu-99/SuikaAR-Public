using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    // 현재 값
    public int currentIndex = 0;

    // 다음 값
    public int nextIndex = 0;

    void Start()
    {
        nextIndex = Random.Range(0, 4); // 1부터 4 중 랜덤 값 설정
    }

    // 다음 값 설정
    public void SetNextIndex()
    {
        nextIndex = Random.Range(0, 4); // 1부터 4 중 랜덤 값 설정
    }

    // 현재 값 가져오기
    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    // 다음 값을 현재 값으로 설정
    public void SetNextAsCurrent()
    {
        currentIndex = nextIndex;
    }
}
