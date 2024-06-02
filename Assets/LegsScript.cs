using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision?");
        FallingTable table = transform.parent.GetComponent<FallingTable>();
        table.Selected = false;
        SpawnManager.Instance.SpawnNext();
    }
}
