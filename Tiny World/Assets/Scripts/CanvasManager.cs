using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Main canvas manager.
/// </summary>
public class CanvasManager : MonoBehaviour
{
    /// <summary>
    /// Singleton.
    /// </summary>
    public static CanvasManager Instance;
    /// <summary>
    /// Bool if a plane is detected.
    /// </summary>
    private bool _planeDetected;
    /// <summary>
    /// References to the screens.
    /// </summary>
    [SerializeField] private GameObject detectionScreen, waitScreen, editScreen, instantiateScreen;
    
    /// <summary>
    /// Returns if the plane detected.
    /// </summary>
    /// <returns>plane is detected.</returns>
    public bool GetPlaneDetected()
    {
        return _planeDetected;
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
    /// <summary>
    /// Show the plane detection screen.
    /// </summary>
    public void ShowPlaneDetection()
    {
        detectionScreen.SetActive(true);
        _planeDetected = false;
    }
    /// <summary>
    /// Hide the plane detection screen.
    /// </summary>
    public void HidePlaneDetection()
    {
        detectionScreen.SetActive(false);
        _planeDetected = true;
    }
    /// <summary>
    /// Show the wait screen.
    /// </summary>
    public void ShowWaitScreen()
    {
        waitScreen.SetActive(true);
    }
    /// <summary>
    /// Hide the wait screen.
    /// </summary>
    public void HideWaitScreen()
    {
        waitScreen.SetActive(false);
    }
    /// <summary>
    /// Show the edit screen.
    /// </summary>
    public void ShowEditScreen()
    {
        editScreen.SetActive(true);
    }
    /// <summary>
    /// Hide the edit screen.
    /// </summary>
    public void HideEditScreen()
    {
        editScreen.SetActive(false);
    }
    /// <summary>
    /// Show the instantiate screen.
    /// </summary>
    public void ShowInstantiateScreen()
    {
        instantiateScreen.SetActive(true);
    }
    /// <summary>
    /// Hide the instantiate screen.
    /// </summary>
    public void HideInstantiateScreen()
    {
        instantiateScreen.SetActive(false);
    }
    /// <summary>
    /// Set the scale of the world.
    /// </summary>
    /// <param name="slider">The slider reference.</param>
    public void SetScale(Slider slider)
    {
        GameManager.Instance.GetWorldMesh().SetScale(Vector3.one * slider.value);
    }
    /// <summary>
    /// Set the x rotation of the world.
    /// </summary>
    /// <param name="slider">The slider reference.</param>
    public void SetXRotation(Slider slider)
    {
        GameManager.Instance.GetWorldMesh().SetXRotation(slider.value);
    }
    /// <summary>
    /// Set the y rotation of the world.
    /// </summary>
    /// <param name="slider">The slider reference.</param>
    public void SetYRotation(Slider slider)
    {
        GameManager.Instance.GetWorldMesh().SetYRotation(slider.value);
    }
}
