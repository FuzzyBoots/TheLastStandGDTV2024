using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTable : MonoBehaviour
{
    Rigidbody _body;
    [SerializeField] private float _fallSpeed = 1f;

    [SerializeField] private bool _selected = false;
    [SerializeField] private float _horizontalVelocity = 0f;
    [SerializeField] private float _horizontalSpeed = 2f;

    Rigidbody Body
    {
        get { 
            if (_body == null) {
                _body = GetComponent<Rigidbody>();
            }
            return _body;
        }
    }

    public bool Selected
    {
        get { return _selected; }
        set { _selected = value; }
    }

    private void Awake()
    {
        Body.velocity = Vector3.down * _fallSpeed;
    }

    private void Update()
    {
        if (_selected)
        {
            _horizontalVelocity = Input.GetAxis("Horizontal") * _horizontalSpeed * Time.deltaTime;
        }

        Body.velocity += Vector3.forward * _horizontalVelocity;
    }
}
