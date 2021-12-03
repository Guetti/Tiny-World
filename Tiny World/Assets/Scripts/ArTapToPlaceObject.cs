using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/// <summary>
/// Class to show the placement indicator and place and object in the current position.
/// </summary>
public class ArTapToPlaceObject : MonoBehaviour
{
    /// <summary>
    /// The singleton.
    /// </summary>
    public static ArTapToPlaceObject Instance;
    /// <summary>
    /// The desired object to place.
    /// </summary>
    public GameObject objectToPlace;
    /// <summary>
    /// Reference to the placement indicator.
    /// </summary>
    public GameObject placementIndicator;
    /// <summary>
    /// The AR Raycast from AR Foundation.
    /// </summary>
    private ARRaycastManager _arRaycast;
    /// <summary>
    /// The placement position
    /// </summary>
    private Pose _placementPose;
    /// <summary>
    /// Bool if the placement position is valid.
    /// </summary>
    private bool _placementPoseIsValid = false;
    /// <summary>
    /// Bool if the object is placed.
    /// </summary>
    private bool _isPlace;

    private void Awake()
    {
        Initialization();
    }
    /// <summary>
    /// Initializes the singleton.
    /// </summary>
    private void Initialization()
    {
        Instance = this;
    }

    private void Start()
    {
        _arRaycast = FindObjectOfType<ARRaycastManager>();
    }
    /// <summary>
    /// Restart the plane detection.
    /// </summary>
    public void Restart()
    {
        _isPlace = false;
    }

    private void Update()
    {
        if (!_isPlace)
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();
        }
        
        if (_placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !_isPlace)
        {
            PlaceObject();
            _isPlace = true;
            placementIndicator.SetActive(false);
        }

    }
    /// <summary>
    /// Place the object in the placement indicator position.
    /// </summary>
    private void PlaceObject()
    {
        var objectPlaced = Instantiate(objectToPlace, _placementPose.position, _placementPose.rotation);
        
        GameManager.Instance.SetWorld(objectPlaced);
        CanvasManager.Instance.ShowWaitScreen();
    }
    /// <summary>
    /// Update the placement indicator position.
    /// </summary>
    private void UpdatePlacementIndicator()
    {
        if (_placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(_placementPose.position, _placementPose.rotation);
            if (!CanvasManager.Instance.GetPlaneDetected())
                CanvasManager.Instance.HidePlaneDetection();
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }
    /// <summary>
    /// Update the placement pose.
    /// </summary>
    private void UpdatePlacementPose()
    {
        var screenCenter = new Vector2 (Screen.width / 2f, Screen.height / 2f);
        var hits = new List<ARRaycastHit>();
        _arRaycast.Raycast(screenCenter, hits, TrackableType.Planes);

        _placementPoseIsValid = hits.Count > 0;
        if (_placementPoseIsValid)
        {
            _placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            _placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}
