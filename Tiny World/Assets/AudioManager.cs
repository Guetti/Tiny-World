using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource treeSource;
    [SerializeField] private AudioSource rockSource;
    [SerializeField] private AudioSource grassSource;
    [SerializeField] private AudioSource flowerSource;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayTree()
    {
        treeSource.Play();
    }

    public void PlayRock()
    {
        rockSource.Play();
    }

    public void PlayGrass()
    {
        grassSource.Play();
    }

    public void PlayFlower()
    {
        flowerSource.Play();
    }
}
