using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditScreenManager : MonoBehaviour
{
    public static EditScreenManager Instance;
    [SerializeField] private Slider scale, yRotation, xRotation;

    private void Awake()
    {
        Instance = this;
    }

    public void ResetSliders()
    {
        scale.value = 0.5f;
        yRotation.value = 0;
        xRotation.value = 0;
    }
}
