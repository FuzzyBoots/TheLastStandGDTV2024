using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _horizontalVelocity;
    private Rigidbody _body;

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

    void Update()
    {
        _horizontalVelocity = Input.GetAxis("Horizontal") * _movementSpeed * Time.deltaTime;
        transform.Translate(Vector3.left * _horizontalVelocity);
    }
}
