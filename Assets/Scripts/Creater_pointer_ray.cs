using UnityEngine;

public class Creater_pointer_ray : MonoBehaviour
{
    public GameObject Line;
    public GameObject Box_object;
    public GameObject Spawnpoint;

    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Line.SetActive(true);
            /*
            // Box_object와 Spawnpoint의 y축 크기 차이 계산
            float heightDifference = Box_object.transform.localScale.y - Spawnpoint.transform.position.y;

            // Line의 y 스케일을 계산한 차이로 설정
            Line.transform.localScale = new Vector3(1f, heightDifference, 1f);

            // Line의 y 위치를 계산한 차이로 설정 (스케일의 절반만큼 위로 이동)
            Line.transform.localPosition = new Vector3(0f, -heightDifference, 0f);
            */
        }
        else
        {
            Line.SetActive(false);
        }
    }
}
