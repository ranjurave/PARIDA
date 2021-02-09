using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class placementManager : MonoBehaviour
{
    private ARRaycastManager arOrigin;
    private Pose placementPose;
    private bool placementPoseIsValid;


    // Start is called before the first frame update
    void Start()
    {
        //arOrigin = FindObjectOfType<ARSessionOrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        var screenCentre = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        //arOrigin.Raycast(screenCentre, hits, trackableTypes.planes);
    }
}
