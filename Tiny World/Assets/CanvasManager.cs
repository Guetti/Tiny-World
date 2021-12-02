using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    private bool _planeDetected;
    [SerializeField] private GameObject detectionScreen, waitScreen, editScreen, instantiateScreen;
    

    public bool GetPlaneDetected()
    {
        return _planeDetected;
    }

    private void Awake()
    {
        Instance = this;
    }
    public void ShowPlaneDetection()
    {
        detectionScreen.SetActive(true);
        _planeDetected = false;
    }

    public void HidePlaneDetection()
    {
        detectionScreen.SetActive(false);
        _planeDetected = true;
    }
    public void ShowWaitScreen()
    {
        waitScreen.SetActive(true);
    }

    public void HideWaitScreen()
    {
        waitScreen.SetActive(false);
    }

    public void ShowEditScreen()
    {
        editScreen.SetActive(true);
    }

    public void HideEditScreen()
    {
        editScreen.SetActive(false);
    }

    public void ShowInstantiateScreen()
    {
        instantiateScreen.SetActive(true);
    }

    public void HideInstantiateScreen()
    {
        instantiateScreen.SetActive(false);
    }

    public void SetScale(Slider slider)
    {
        GameManager.Instance.GetWorldMesh().SetScale(Vector3.one * slider.value);
    }

    public void SetXRotation(Slider slider)
    {
        GameManager.Instance.GetWorldMesh().SetXRotation(slider.value);
    }

    public void SetYRotation(Slider slider)
    {
        GameManager.Instance.GetWorldMesh().SetYRotation(slider.value);
    }
}
