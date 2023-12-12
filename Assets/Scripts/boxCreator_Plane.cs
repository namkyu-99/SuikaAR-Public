using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class boxCreator_Plane : MonoBehaviour
{
    public GameObject AROrigin;
    ARPointCloudManager arPointCloudManager;
    ARPlaneManager arPlaneManager;
    ARRaycastManager arRaycaster;
    public GameObject ARPointCloud;
    public GameObject ARPlane;
    public GameObject Box;
    public boxCreator_Image boxCreator_image;
    
    void Start()
    {
        arPointCloudManager = AROrigin.GetComponent<ARPointCloudManager>();
        arPlaneManager = AROrigin.GetComponent<ARPlaneManager>();
        arRaycaster = AROrigin.GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        CreateBox();
    }

    void CreateBox()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (arRaycaster.Raycast(touch.position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
            {
                Pose touchPose = hits[0].pose;
                Box.SetActive(true);
                Box.transform.SetPositionAndRotation(touchPose.position, touchPose.rotation);

                Disable();
                boxCreator_image.Disable();
            }
        }
    }

    public void Disable()
    {
        arPointCloudManager.enabled = false;
        arPlaneManager.enabled = false;
        GameObject[] Planes = GameObject.FindGameObjectsWithTag("Plane");
        foreach (GameObject plane in Planes) {
            Destroy(plane);
        }
        Destroy(this.gameObject);
    }
}
