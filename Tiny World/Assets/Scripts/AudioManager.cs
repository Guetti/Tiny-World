using UnityEngine;
/// <summary>
/// The audio manager.
/// </summary>
public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// Singleton.
    /// </summary>
    public static AudioManager Instance;
    /// <summary>
    /// The audio source from trees.
    /// </summary>
    [SerializeField] private AudioSource treeSource;
    /// <summary>
    /// The audio source from rocks.
    /// </summary>
    [SerializeField] private AudioSource rockSource;
    /// <summary>
    /// The audio source from grass.
    /// </summary>
    [SerializeField] private AudioSource grassSource;
    /// <summary>
    /// The audio source from flowers.
    /// </summary>
    [SerializeField] private AudioSource flowerSource;
    /// <summary>
    /// The audio source from the world.
    /// </summary>
    [SerializeField] private AudioSource worldSource;
    
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
    /// Reproduce the tree sound.
    /// </summary>
    public void PlayTree()
    {
        treeSource.Play();
    }
    /// <summary>
    /// Reproduce the rock sound.
    /// </summary>
    public void PlayRock()
    {
        rockSource.Play();
    }
    /// <summary>
    /// Reproduce the grass sound.
    /// </summary>
    public void PlayGrass()
    {
        grassSource.Play();
    }
    /// <summary>
    /// Reproduce the flower sound.
    /// </summary>
    public void PlayFlower()
    {
        flowerSource.Play();
    }

    public void PlayWorld()
    {
        worldSource.Play();
    }
}
