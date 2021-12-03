using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Manager from the edit screen.
/// </summary>
public class EditScreenManager : MonoBehaviour
{
    /// <summary>
    /// Singleton.
    /// </summary>
    public static EditScreenManager Instance;
    /// <summary>
    /// Sliders from scale, y rotation and x rotation.
    /// </summary>
    [SerializeField] private Slider scale, yRotation, xRotation;

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
    /// <summary>
    /// Reset the sliders to the default configuration.
    /// </summary>
    public void ResetSliders()
    {
        scale.value = 0.5f;
        yRotation.value = 0;
        xRotation.value = 0;
    }
}
