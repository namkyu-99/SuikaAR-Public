using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnClick : MonoBehaviour
{
    [SerializeField] private GameObject[] arObject;
    public GameObject GameSystem_Object;
    private GameSystem gameSystem;
    public AudioSource Drop;

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
            new Vector3(trackingInfo.skeleton.joints[4].x, trackingInfo.skeleton.joints[4].y, trackingInfo.skeleton.joints[4].z),
            depthEstimation
        );

        // 현재 값 가져오기
        int currentIndex = gameSystem.GetCurrentIndex();

        // 다음 값 설정
        gameSystem.SetNextIndex();

        // 다음다음 값 설정
        gameSystem.SetNextNextIndex();

        // 현재 값에 해당하는 오브젝트 생성
        Instantiate(arObject[currentIndex], jointPosition, Quaternion.identity);

        // nextIndex 값을 currentIndex로 옮김
        gameSystem.SetNextAsCurrent();

        // 진동
        if(System.Convert.ToBoolean(PlayerPrefs.GetInt("Vibration", 1)))
            Handheld.Vibrate();

        // 효과음 재생
        Drop.Play();
    }
}
