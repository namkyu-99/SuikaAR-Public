using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    

    public GameObject[] arObject;
    // Start is called before the first frame update
    public GameObject GameSystem_Object;
    private GameSystem gameSystem;
    public GameObject Pointer;

    void Start()
    {
        // GameSystem 컴포넌트 찾아서 참조
        gameSystem = GameSystem_Object.GetComponent<GameSystem>();
        if (gameSystem == null)
        {
            Debug.LogError("GameSystem이 찾을 수 없습니다.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        ManomotionManager.Instance.ShouldCalculateGestures(true);

        GestureInfo gestureInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info;

        ManoGestureTrigger currentGesture = gestureInfo.mano_gesture_trigger;

        ManomotionManager.Instance.ShouldCalculateSkeleton3D(true);

        TrackingInfo trackingInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info;

        float depthEstimation = trackingInfo.depth_estimation;

        Vector3 jointPosition = ManoUtils.Instance.CalculateNewPositionSkeletonJointDepth(new Vector3(trackingInfo.skeleton.joints[8].x, trackingInfo.skeleton.joints[8].y, trackingInfo.skeleton.joints[8].z), depthEstimation);

        //float target_to_ground = jointPosition.y;
       
        // 현재 값 가져오기
        int currentIndex = gameSystem.GetCurrentIndex();
        Pointer.transform.position = jointPosition;

        if (arObject[currentIndex] != null)
        {
            arObject[currentIndex].transform.position = jointPosition;
            arObject[currentIndex].SetActive(true);
        }
        foreach (GameObject obj in arObject)
        {
            if (obj != arObject[currentIndex])
            {
                obj.transform.position = Vector3.zero;
                obj.SetActive(false);
            }
        }
        
        //Debug.DrawRay(jointPosition, jointPosition - Vector3.up * target_to_ground, Color.red, 10);
    }
}
