using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
/// <summary>
/// Instantiate manager for show different props in the world.
/// </summary>
public class InstantiateManager : MonoBehaviour
{
    /// <summary>
    /// Singleton
    /// </summary>
    public static InstantiateManager Instance;
    /// <summary>
    /// Trees game object list.
    /// </summary>
    [SerializeField] private List<GameObject> trees;
    /// <summary>
    /// Rocks game object list.
    /// </summary>
    [SerializeField] private List<GameObject> rocks;
    /// <summary>
    /// decorations game object list.
    /// </summary>
    [SerializeField] private List<GameObject> decorations;
    /// <summary>
    /// Grass game object list.
    /// </summary>
    [SerializeField] private List<GameObject> grass;
    /// <summary>
    /// Fall trees game object list.
    /// </summary>
    [SerializeField] private List<GameObject> fallTrees;
    /// <summary>
    /// sand rocks game object list.
    /// </summary>
    [SerializeField] private List<GameObject> sandRocks;
    /// <summary>
    /// The selected index of list.
    /// 0 = trees
    /// 1 = rocks
    /// 2 = decorations
    /// 3 = grass
    /// 4 = fall trees
    /// 5 = sandRocks
    /// </summary>
    private int _selectedList = -1;

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
    /// Select the desired list of objects.
    /// </summary>
    /// <param name="list">list index.</param>
    public void SelectList(int list)
    {
        _selectedList = list;
    }
    /// <summary>
    /// Make the selected list to -1 (nothing).
    /// </summary>
    public void DeselectList()
    {
        _selectedList = -1;
    }
    /// <summary>
    /// Spawns a random object in the world.
    /// </summary>
    /// <param name="position">The desired position.</param>
    /// <param name="rotation">The desired rotation.</param>
    /// <param name="scale">The desired scale.</param>
    /// <param name="normal">The normal vector.</param>
    public void Generate(Vector3 position, Quaternion rotation, Vector3 scale, Vector3 normal)
    {
        if (_selectedList == -1) return;
        GameObject objectToPlace;
        switch (_selectedList)
        {
            case 0:
                objectToPlace = Instantiate(trees[GetRandomInt(trees.Count)], position, rotation);
                AudioManager.Instance.PlayTree();
                break;
            case 1:
                objectToPlace = Instantiate(rocks[GetRandomInt(rocks.Count)], position, rotation);
                AudioManager.Instance.PlayRock();
                break;
            case 2:
                objectToPlace = Instantiate(decorations[GetRandomInt(decorations.Count)], position, rotation);
                AudioManager.Instance.PlayFlower();
                break;
            case 3:
                objectToPlace = Instantiate(grass[GetRandomInt(grass.Count)], position, rotation);
                AudioManager.Instance.PlayGrass();
                break;
            case 4:
                objectToPlace = Instantiate(fallTrees[GetRandomInt(fallTrees.Count)], position, rotation);
                AudioManager.Instance.PlayTree();
                break;
            case 5:
                objectToPlace = Instantiate(sandRocks[GetRandomInt(sandRocks.Count)], position, rotation);
                AudioManager.Instance.PlayRock();
                break;
            default: 
                objectToPlace = null;
                break;
        }

        if (!objectToPlace) return;
        if (objectToPlace is null) return;
        objectToPlace.transform.parent = GameManager.Instance.GetWorldMesh().transform;
        //objectToPlace.transform.localScale = scale;
        objectToPlace.transform.localScale = Vector3.zero;
        objectToPlace.transform.localPosition -= normal.normalized * 0.01f;
        objectToPlace.transform.LeanScale(scale, 1f).setEaseOutQuad();
    }
    /// <summary>
    /// Generate a random integer value.
    /// </summary>
    /// <param name="maxValueExclusive">The max value.</param>
    /// <returns>The random integer.</returns>
    private static int GetRandomInt(int maxValueExclusive)
    {
        return Random.Range(0, maxValueExclusive);
    }
}
