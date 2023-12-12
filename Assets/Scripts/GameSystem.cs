using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    // 현재 값
    public int currentIndex = 0;

    // 다음 값
    public int nextIndex = 0;

    // 다다음 값
    public int nextnextIndex = 0;

    //과일 갯수(motionInteraction에서 배열 길이 참조하는것으로 구현하면 더 유기적이나 직접 설정해줌)
    public int fruit_num = 5;

    void Start()
    {
        nextIndex = Random.Range(0, fruit_num); // 1부터 4 중 랜덤 값 설정
        nextnextIndex = Random.Range(0, fruit_num);
    }

    // 다음 값 설정
    public void SetNextIndex()
    {
        nextIndex = nextnextIndex;
    }
    // 다다음 값 설정
    public void SetNextNextIndex()
    {
        nextnextIndex = Random.Range(0, fruit_num); // 1부터 4 중 랜덤 값 설정
    }

    // 현재 값 가져오기
    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    // 다음 값 가져오기
    public int GetNextIndex()
    {
        return nextIndex;
    }

    // 다다음 값 가져오기
    public int GetNextNextIndex()
    {
        return nextnextIndex;
    }

    // 다음 값을 현재 값으로 설정
    public void SetNextAsCurrent()
    {
        currentIndex = nextIndex;
    }

}
