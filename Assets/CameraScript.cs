using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CameraScript : MonoBehaviour
{
    [SerializeField] MovingPlatform _platform;
    [SerializeField] SpawnManager _spawnManager;
    Camera _camera;
    [SerializeField] float _minCameraDist = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(_spawnManager, "Did not define Spawn Manager!");
        Assert.IsNotNull(_platform, "Did not define Platform!");
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        float _halfwayY = (_spawnManager.transform.position.y - _platform.transform.position.y) / 2;
        float cameraDist = _halfwayY / Mathf.Tan(Mathf.Deg2Rad * _camera.fieldOfView) + 1;
        Debug.Log("CameraDist would be " + cameraDist);
        if (cameraDist > _minCameraDist)
        {
            position.y = _halfwayY + _platform.transform.position.y;
            position.z = cameraDist;
            // Debug.Break();
            Debug.Log($"Setting camera to {position}");

            transform.position = position;
        }
    }
}
