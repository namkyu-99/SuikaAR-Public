using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class boxCreator1 : MonoBehaviour
{
    public GameObject XROrigin;
    ARPointCloudManager arPointCloudManager;
    ARPlaneManager arPlaneManager;
    public ARRaycastManager arRaycaster;
    public GameObject ARPointCloud;
    public GameObject ARPlane;
    public GameObject Box;
    
    void Start()
    {
        arPointCloudManager = XROrigin.GetComponent<ARPointCloudManager>();
        arPlaneManager = XROrigin.GetComponent<ARPlaneManager>();
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
            }
        }
    }

    void Disable()
    {
        arPointCloudManager.enabled = false;
        arPlaneManager.enabled = false;
        // ARPointCloud.SetActive(false);
        // ARPlane.SetActive(false);
        GameObject[] Planes = GameObject.FindGameObjectsWithTag("Plane");
        foreach (GameObject plane in Planes) {
            Destroy(plane);
        }
        this.gameObject.SetActive(false);
    }
}
