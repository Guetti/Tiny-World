using UnityEngine;
/// <summary>
/// Class World.
/// </summary>
public class World : MonoBehaviour, ITouchable
{
    [SerializeField] private LeanTweenType ease;
    private float _yRotation, _xRotation;
    private void Start()
    {
        Expand();
    }
    /// <summary>
    /// Animate the object to grow.
    /// </summary>
    private void Expand()
    {
        const float time = 2f;
        transform.localScale = Vector3.zero;
        transform.LeanScale(Vector3.one / 2f, time).setEaseOutBack();
    }
    
    /// <summary>
    /// Change the scale of the World.
    /// </summary>
    /// <param name="scale"></param>
    public void SetScale(Vector3 scale)
    {
        transform.localScale = scale;
    }
    /// <summary>
    /// Change the X rotation.
    /// </summary>
    /// <param name="xRotation"></param>
    public void SetXRotation(float xRotation)
    {
        var rotation = new Vector3(xRotation, _yRotation, transform.localRotation.z);
        transform.localRotation = Quaternion.Euler(rotation);
        _xRotation = xRotation;
    }
    /// <summary>
    /// Change the Y rotation.
    /// </summary>
    /// <param name="yRotation"></param>
    public void SetYRotation(float yRotation)
    {
        var rotation = new Vector3(_xRotation, yRotation, transform.localRotation.z);
        transform.localRotation = Quaternion.Euler(rotation);
        _yRotation = yRotation;
    }
}
