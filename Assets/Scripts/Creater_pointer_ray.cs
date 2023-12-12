using UnityEngine;

public class Creater_pointer_ray : MonoBehaviour
{
    public GameObject Line;
    public GameObject Point;
    public GameObject Box_object;
    public GameObject Spawnpoint;

    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        int layerMask = 1 << LayerMask.NameToLayer("RayHit");

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Line.SetActive(true);
            Point.SetActive(true);
            /*
            // Box_object와 Spawnpoint의 y축 크기 차이 계산
            float heightDifference = Box_object.transform.localScale.y - Spawnpoint.transform.position.y;

            // Line의 y 스케일을 계산한 차이로 설정
            Line.transform.localScale = new Vector3(1f, heightDifference, 1f);

            // Line의 y 위치를 계산한 차이로 설정 (스케일의 절반만큼 위로 이동)
            Line.transform.localPosition = new Vector3(0f, -heightDifference, 0f);
            */
            float heightDifference = Mathf.Abs(hit.point.y - transform.position.y);
            Line.transform.localScale = new Vector3(0.001f, heightDifference, 0.001f);
            Line.transform.localPosition = new Vector3(0, -heightDifference, 0);
            Point.transform.position = hit.point;
        }
        else
        {
            Line.SetActive(false);
            Point.SetActive(false);
        }
    }
}
