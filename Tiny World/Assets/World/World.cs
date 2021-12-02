using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour, ITouchable
{
    [SerializeField] private LeanTweenType ease;
    private void Start()
    {
        //Animate();
        Expand();
    }

    public void Animate()
    {
        const float verticalDisplacement = 0.2f;
        const float time = 2f;
        transform.LeanMoveLocalY(transform.position.y + verticalDisplacement, time).setLoopPingPong().setEase(ease);
    }
    
    private void Expand()
    {
        const float time = 2f;
        transform.localScale = Vector3.zero;
        transform.LeanScale(Vector3.one / 2f, time).setEaseOutBack();
    }

    public void Interact()
    {
        
    }

    public void SetScale(Vector3 scale)
    {
        transform.localScale = scale;
    }

    public void SetXRotation(float xRotation)
    {
        //transform.Rotate(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(xRotation, transform.rotation.y, transform.rotation.z);
    }

    public void SetYRotation(float yRotation)
    {
        //transform.Rotate(0, yRotation, 0);
        transform.rotation = Quaternion.Euler(transform.rotation.x, yRotation, transform.rotation.z);
    }
}
