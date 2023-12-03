using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Debugger : MonoBehaviour
{
    public TextMeshProUGUI Log;

    public GameObject XROrigin;
    ARPointCloudManager arPointCloudManager;
    ARPlaneManager arPlaneManager;
    public GameObject ARPointCloud;
    public GameObject ARPlane;
    public GameObject Box;
    public boxCreator1 boxCreator;
    float step = 0.01f;

    void Start()
    {
        arPointCloudManager = XROrigin.GetComponent<ARPointCloudManager>();
        arPlaneManager = XROrigin.GetComponent<ARPlaneManager>();
    }

    void Update()
    {
        Log.text =    "Box Scale: " + Box.transform.localScale + '\n'
                    + "AR Point Cloud Manager: " + arPointCloudManager.enabled + '\n'
                    + "AR Plane Manager: " + arPlaneManager.enabled + '\n'
                    + "AR Point Cloud: " + ARPointCloud.activeSelf + '\n'
                    + "AR Plane: " + ARPlane.activeSelf + '\n'
                    + "boxCreator1: " + boxCreator.enabled;
    }

    public void Up()
    {
        Box.transform.localScale += new Vector3(step, step, step);
    }

    public void Down()
    {
        Box.transform.localScale -= new Vector3(step, step, step);
    }
}
