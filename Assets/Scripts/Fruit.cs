using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour
{
    public GameObject nextStageFruitPrefab; // 다음 단계 과일 프리팹
    public GameObject EffectPrefab; // 충돌 이펙트 프리팹
    private int instanceID; // 과일의 인스턴스 ID
    private float changeDelay = 0.05f; // 과일 변경 전의 딜레이 시간

    private void Start()
    {
        instanceID = GetInstanceID();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Fruit otherFruit = collision.gameObject.GetComponent<Fruit>();

        if (otherFruit != null && gameObject.tag == collision.gameObject.tag)
        {
            if (instanceID < otherFruit.instanceID)
            {
                StartCoroutine(ChangeFruit(collision.gameObject));
            }
        }
    }

    private IEnumerator ChangeFruit(GameObject other)
    {
        // 지연 시간을 기다립니다.
        yield return new WaitForSeconds(changeDelay);

        // 생성 위치는 두 과일의 중간 지점
        Vector3 spawnPosition = (transform.position + other.transform.position) / 2;

        // 새로운 과일 생성
        Instantiate(nextStageFruitPrefab, spawnPosition, Quaternion.identity);
        Instantiate(EffectPrefab, spawnPosition, Quaternion.identity);
        Score.UpdateScore(nextStageFruitPrefab.tag);


        // 현재 과일과 충돌한 과일을 파괴
        Destroy(other);
        Destroy(gameObject);
    }
}
