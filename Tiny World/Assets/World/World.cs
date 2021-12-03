using UnityEngine;
/// <summary>
/// Class World.
/// </summary>
public class World : MonoBehaviour, ITouchable
{
    [SerializeField] private LeanTweenType ease;
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
        //transform.Rotate(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(xRotation, transform.rotation.y, transform.rotation.z);
    }
    /// <summary>
    /// Change the Y rotation.
    /// </summary>
    /// <param name="yRotation"></param>
    public void SetYRotation(float yRotation)
    {
        //transform.Rotate(0, yRotation, 0);
        transform.rotation = Quaternion.Euler(transform.rotation.x, yRotation, transform.rotation.z);
    }
}
