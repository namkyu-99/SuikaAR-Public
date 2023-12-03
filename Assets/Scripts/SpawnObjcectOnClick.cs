using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnClick : MonoBehaviour
{
    [SerializeField] private GameObject[] arObject;
    public GameObject GameSystem_Object;
    private GameSystem gameSystem;

    void Start()
    {
        // GameSystem 컴포넌트 찾아서 참조
        gameSystem = GameSystem_Object.GetComponent<GameSystem>();
        if (gameSystem == null)
        {
            Debug.LogError("GameSystem이 찾을 수 없습니다.");
        }
    }

    void Update()
    {
        ManomotionManager.Instance.ShouldCalculateGestures(true);
        GestureInfo gestureInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info;
        ManoGestureTrigger currentGesture = gestureInfo.mano_gesture_trigger;

        if (currentGesture == ManoGestureTrigger.CLICK)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        ManomotionManager.Instance.ShouldCalculateSkeleton3D(true);
        TrackingInfo trackingInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info;
        float depthEstimation = trackingInfo.depth_estimation;
        Vector3 jointPosition = ManoUtils.Instance.CalculateNewPositionSkeletonJointDepth(
            new Vector3(trackingInfo.skeleton.joints[8].x, trackingInfo.skeleton.joints[8].y, trackingInfo.skeleton.joints[8].z),
            depthEstimation
        );

        // 현재 값 가져오기
        int currentIndex = gameSystem.GetCurrentIndex();

        // 다음 값 설정
        gameSystem.SetNextIndex();

        // 현재 값에 해당하는 오브젝트 생성
        Instantiate(arObject[currentIndex], jointPosition, Quaternion.identity);

        Handheld.Vibrate();

        // nextIndex 값을 currentIndex로 옮김
        gameSystem.SetNextAsCurrent();
    }
}
