using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _horizontalVelocity;
    private Rigidbody _body;

    [SerializeField] GameObject _containerObject;

    Rigidbody Body
    {
        get
        {
            if (_body == null)
            {
                _body = GetComponent<Rigidbody>();
            }
            return _body;
        }
    }

    private void FixedUpdate()
    {
        Body.AddForce(Vector3.right *  _horizontalVelocity, ForceMode.VelocityChange);
    }

    void Update()
    {
        // Check for the highest extant piece of furniture
        float _highestY = transform.position.y;
        for (int i = 0; i<_containerObject.transform.childCount; ++i)
        {
            Transform itemTransform = _containerObject.transform.GetChild(i);
            if ( itemTransform.position.y > _highestY)
            {
                _highestY = itemTransform.position.y;
            }
        }

        // Calculate FOV?
        // For now, we'll estimate
        Debug.Log($"Highest is {_highestY}");
        SpawnManager.Instance.SetHighestPoint(_highestY);

        _horizontalVelocity = Input.GetAxis("Horizontal") * _movementSpeed * Time.deltaTime;
    }
}
