using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class boxCreator_Image : MonoBehaviour
{
    public ARTrackedImageManager arTrackedImageManager;
    public boxCreator_Plane boxCreator_plane;

    void OnEnable() => arTrackedImageManager.trackedImagesChanged += OnChanged;

    void OnDisable() => arTrackedImageManager.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            // Handle added event
            // Disable();
            Invoke("Disable", 0.1f);
            boxCreator_plane.Disable();
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            // Handle updated event
        }

        foreach (var removedImage in eventArgs.removed)
        {
            // Handle removed event
        }
    }

    public void Disable()   // 제대로 작동하지 않음. 계속 트래킹되는 이슈 발생. 다만 QR코드가 고정되어 있다면 큰 문제는 없다.
    {
        arTrackedImageManager.enabled = false;
        Destroy(this.gameObject);
    }
}
