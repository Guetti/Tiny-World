using UnityEngine;

/// <summary>
/// The main game manager.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Singleton.
    /// </summary>
    public static GameManager Instance;

    /// <summary>
    /// Reference to the main camera.
    /// </summary>
    [SerializeField] private new Camera camera;

    /// <summary>
    /// Reference to the world.
    /// </summary>
    [SerializeField] private GameObject world;

    /// <summary>
    /// Reference to the world mesh.
    /// </summary>
    [SerializeField] private GameObject worldMesh;

    /// <summary>
    /// Get the world mesh.
    /// </summary>
    /// <returns>The world mesh.</returns>
    public World GetWorldMesh()
    {
        return worldMesh.GetComponent<World>();
    }

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
        CanvasManager.Instance.ShowPlaneDetection();
        CanvasManager.Instance.HideWaitScreen();
        CanvasManager.Instance.HideEditScreen();
        CanvasManager.Instance.HideInstantiateScreen();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            switch (Input.touches[0].phase)
            {
                case TouchPhase.Began:
                    Touch();
                    break;
            }
        }
    }

    /// <summary>
    /// Detect the touch via android device.
    /// </summary>
    private void Touch()
    {
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        const float rayDistance = 100f;
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
        if (!Physics.Raycast(ray, out var hit, rayDistance)) return;
        if (hit.collider == null) return;
        var touchable = hit.collider.GetComponent<ITouchable>();
        if (touchable != null)
        {
            InstantiateManager.Instance.Generate(hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal),
                Vector3.one / 4f, hit.normal);
        }
    }
    /// <summary>
    /// Set the world reference.
    /// </summary>
    /// <param name="newWorld">The new world instantiated.</param>
    public void SetWorld(GameObject newWorld)
    {
        world = newWorld;
        worldMesh = newWorld.transform.Find("Mesh").gameObject;
        AudioManager.Instance.PlayWorld();
    }
    /// <summary>
    /// Removes the actual world.
    /// </summary>
    public void DeleteWorld()
    {
        Destroy(world.gameObject);
        ArTapToPlaceObject.Instance.Restart();
        EditScreenManager.Instance.ResetSliders();
    }
    
}
