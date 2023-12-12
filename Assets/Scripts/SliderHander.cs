using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SliderHandler : MonoBehaviour, IEndDragHandler
{
    public Slider slider;
    public UnityEvent onSliderRelease;

    private void Start()
    {
        // 슬라이더의 OnValueChanged 이벤트에 함수를 등록
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        // 슬라이더 값이 변경될 때 호출되는 함수
        // 여기에는 드래그 중에도 호출되지만, 실제 값을 추적하는 데 사용할 수 있습니다.
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 드래그가 끝났을 때 호출되는 함수
        if (onSliderRelease != null)
        {
            onSliderRelease.Invoke();
        }
    }

    private void OnDestroy()
    {
        // 스크립트가 파괴될 때 이벤트 리스너를 제거
        slider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }
}
