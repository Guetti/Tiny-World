using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Camera camera;
    public GameObject prefab;
    [SerializeField]private GameObject _world;
    [SerializeField]private GameObject _worldMesh;

    public World GetWorldMesh()
    {
        return _worldMesh.GetComponent<World>();
    }
    private void Awake()
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

        if (Input.GetMouseButtonDown(0))
        {
            MouseTouch();
        }
    }

    private void MouseTouch()
    {
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        const float rayDistance = 100f;
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider != null)
            {
                var touchable = hit.collider.GetComponent<ITouchable>();
                if (touchable != null)
                {
                    InstantiateManager.Instance.Generate(hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal),
                        Vector3.one / 4f, hit.normal);
                }
                
            }
        }
    }

    private void Touch()
    {
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        const float rayDistance = 100f;
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider != null)
            {
                var touchable = hit.collider.GetComponent<ITouchable>();
                if (touchable != null)
                {
                    InstantiateManager.Instance.Generate(hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal),
                        Vector3.one / 4f, hit.normal);
                }
                
            }
        }
    }

    public void SetWorld(GameObject world)
    {
        this._world = world;
        this._worldMesh = world.transform.Find("Mesh").gameObject;
    }

    public void DeleteWorld()
    {
        Destroy(_world.gameObject);
        ArTapToPlaceObject.Instance.Restart();
    }
    
}
