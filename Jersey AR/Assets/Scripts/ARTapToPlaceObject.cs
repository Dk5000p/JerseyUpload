using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject jersey;
    private GameObject spawnedObject;
    private ARRaycastManager _arRaycastManager;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    [SerializeField]
    private Pose hitPose;
    // Start is called before the first frame update
    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }
        if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            hitPose = hits[0].pose;
            

        }
    }
    public void CreateObject()
    {
        spawnedObject = Instantiate(jersey, hitPose.position, hitPose.rotation);
    }
}
  
