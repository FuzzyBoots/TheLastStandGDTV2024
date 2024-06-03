
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenaltyZone : MonoBehaviour
{
    [SerializeField] GameObject _containerObject;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Loss Screen");
        GameManager.Instance.LossScreen();
        GameObject toBeDestroyed = other.gameObject;
        while (toBeDestroyed.transform.parent != null && toBeDestroyed.transform.parent.gameObject.name != _containerObject.name) {
            toBeDestroyed = toBeDestroyed.transform.parent.gameObject;
        }
        Debug.Log($"Should be destroying {toBeDestroyed.name}");
        Destroy(toBeDestroyed);
    }
}
