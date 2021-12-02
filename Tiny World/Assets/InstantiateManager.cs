using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InstantiateManager : MonoBehaviour
{
    public static InstantiateManager Instance;
    [SerializeField] private List<GameObject> trees;
    [SerializeField] private List<GameObject> rocks;
    [SerializeField] private List<GameObject> decorations;
    [SerializeField] private List<GameObject> grass;
    [SerializeField] private List<GameObject> fences;
    [SerializeField] private List<GameObject> sandRocks;
    /// <summary>
    /// 0 = trees
    /// 1 = rocks
    /// 2 = decorations
    /// 3 = grass
    /// 4 = fences
    /// 5 = sandRocks
    /// </summary>
    private int selectedList = -1;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectList(int list)
    {
        selectedList = list;
    }

    public void DeselectList()
    {
        selectedList = -1;
    }
    public void Generate(Vector3 position, Quaternion rotation, Vector3 scale, Vector3 normal)
    {
        if (selectedList == -1) return;
        GameObject objectToPlace;
        switch (selectedList)
        {
            case 0:
                objectToPlace = Instantiate(trees[GetRandomInt(trees.Count)], position, rotation);
                break;
            case 1:
                objectToPlace = Instantiate(rocks[GetRandomInt(rocks.Count)], position, rotation);
                break;
            case 2:
                objectToPlace = Instantiate(decorations[GetRandomInt(decorations.Count)], position, rotation);
                break;
            case 3:
                objectToPlace = Instantiate(grass[GetRandomInt(grass.Count)], position, rotation);
                break;
            case 4:
                objectToPlace = Instantiate(fences[GetRandomInt(fences.Count)], position, rotation);
                break;
            case 5:
                objectToPlace = Instantiate(sandRocks[GetRandomInt(sandRocks.Count)], position, rotation);
                break;
            default: 
                objectToPlace = null;
                break;
        }

        if (objectToPlace)
        {
            objectToPlace.transform.parent = GameManager.Instance.GetWorldMesh().transform;
            objectToPlace.transform.localScale = scale;
            objectToPlace.transform.localPosition -= normal.normalized * 0.05f;
        }
        
    }

    private int GetRandomInt(int maxValueExclusive)
    {
        return Random.Range(0, maxValueExclusive);
    }
}
