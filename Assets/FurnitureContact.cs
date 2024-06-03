using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureContact : MonoBehaviour
{
    private bool _stacked;

    private void OnCollisionEnter(Collision collision)
    {
        // If any contact is made, we count this toward stacked items
        _stacked = true;
    }
}
